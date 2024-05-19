using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Characters.Starships;

/// <summary>
/// Handler to process a <see cref="ListCharacterStarships"/> command and return a
/// <see cref="ListCharacterStarshipsResult"/>.
/// </summary>
internal class ListCharacterStarshipsHandler
    : IQueryHandler<ListCharacterStarships, ListCharacterStarshipsResult>
{
    private readonly ICharactersStore _peopleStore;
    private readonly IStarshipsStore _starshipsStore;

    public ListCharacterStarshipsHandler(ICharactersStore peopleStore,
        IStarshipsStore starshipsStore)
    {
        this._peopleStore = peopleStore;
        this._starshipsStore = starshipsStore;
    }

    public async Task<ListCharacterStarshipsResult> HandleAsync(ListCharacterStarships query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            await this.ValidateAsync(query, cancellation);
            var page = await this._starshipsStore.ListAsync(query.Filter, cancellation);
            return ListCharacterStarshipsResult.Success(page);
        }
        catch (ListCharacterStarshipsException ex)
        {
            return ListCharacterStarshipsResult.Failure(ex);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return ListCharacterStarshipsResult.Failure(ListCharacterStarshipsException.Fault($"Failed to list starships for person `{query.Filter.PersonId!.Value}`.", ex));
        }
        throw new NotImplementedException();
    }

    private async Task ValidateAsync(ListCharacterStarships query, CancellationToken cancellation = default)
    {
        _ = await this._peopleStore.FetchAsync(query.Filter.PersonId!.Value, cancellation)
            ?? throw ListCharacterStarshipsException.NotFound(query.Filter.PersonId.Value);
    }
}
