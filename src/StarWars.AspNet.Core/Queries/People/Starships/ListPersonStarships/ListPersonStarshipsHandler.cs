
using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.People.Starships;

internal class ListPersonStarshipsHandler
    : IQueryHandler<ListPersonStarships, ListPersonStarshipsResult>
{
    private readonly IPeopleStore _peopleStore;
    private readonly IStarshipsStore _starshipsStore;

    public ListPersonStarshipsHandler(IPeopleStore peopleStore,
        IStarshipsStore starshipsStore)
    {
        this._peopleStore = peopleStore;
        this._starshipsStore = starshipsStore;
    }

    public async Task<ListPersonStarshipsResult> HandleAsync(ListPersonStarships query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            await this.ValidateAsync(query, cancellation);
            var page = await this._starshipsStore.ListAsync(query.Filter, cancellation);
            return ListPersonStarshipsResult.Success(page);
        }
        catch (ListPersonStarshipsException ex)
        {
            return ListPersonStarshipsResult.Failure(ex);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return ListPersonStarshipsResult.Failure(ListPersonStarshipsException.Fault($"Failed to list starships for person `{query.Filter.PersonId!.Value}`.", ex));
        }
        throw new NotImplementedException();
    }

    private async Task ValidateAsync(ListPersonStarships query, CancellationToken cancellation = default)
    {
        _ = await this._peopleStore.FetchAsync(query.Filter.PersonId!.Value, cancellation)
            ?? throw ListPersonStarshipsException.NotFound(query.Filter.PersonId.Value);
    }
}
