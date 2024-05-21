
using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Characters;

/// <summary>
/// Handler to process a <see cref="FetchCharacterById"/> query and return a
/// <see cref="FetchCharacterByIdResult"/>.
/// </summary>
internal class FetchCharacterByIdHandler
    : IQueryHandler<FetchCharacterById, FetchCharacterByIdResult>
{
    private readonly ICharactersStore _characterStore;

    public FetchCharacterByIdHandler(ICharactersStore characterStore)
    {
        this._characterStore = characterStore;
    }

    public async Task<FetchCharacterByIdResult> HandleAsync(FetchCharacterById query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var character = await this._characterStore.FetchAsync(query.CharacterId, cancellation);
            if (character is null)
            {
                return FetchCharacterByIdResult.NotFound(query.CharacterId);
            }
            return FetchCharacterByIdResult.Success(character);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return FetchCharacterByIdResult.Failure(FetchCharacterByIdException.Fault($"Failed to fetch a character by id `{query.CharacterId.Value}`.", ex));
        }
    }
}
