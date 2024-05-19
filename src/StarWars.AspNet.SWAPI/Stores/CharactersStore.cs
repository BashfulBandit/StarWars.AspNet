using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.People;

namespace StarWars.AspNet.SWAPI.Stores;

/// <inheritdoc />
internal class CharactersStore
    : ICharactersStore
{
    private readonly ILogger<CharactersStore> _logger;
    private readonly ISWAPIClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="CharactersStore"/>.
    /// </summary>
    public CharactersStore(ILogger<CharactersStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<Character?> FetchAsync(CharacterId id, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var request = id.ToRequest();
            var response = await this._client.People.RetrieveAsync(request, cancellation);
            return response.ToModel();
        }
        catch (SWAPIClientNotFoundException)
        {
            return null;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to fetch Person {personId}.", id.Value);
            throw new CharactersStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }
}
