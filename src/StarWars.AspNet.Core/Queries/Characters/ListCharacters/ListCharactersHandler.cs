
using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Characters;

internal class ListCharactersHandler
    : IQueryHandler<ListCharacters, ListCharactersResult>
{
    private readonly ICharactersStore _charactersStore;

    public ListCharactersHandler(ICharactersStore charactersStore)
    {
        this._charactersStore = charactersStore;
    }

    public async Task<ListCharactersResult> HandleAsync(ListCharacters query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var page = await this._charactersStore.ListAsync(query.Filter, cancellation);
            return ListCharactersResult.Success(page);
        }
        catch (Exception ex)
        {
            return ListCharactersResult.Failure(ListCharactersException.Fault($"Failed to list characters.", ex));
        }
    }
}
