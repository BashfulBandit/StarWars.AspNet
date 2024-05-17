using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.Films;

namespace StarWars.AspNet.SWAPI.Stores;

internal class FilmsStore
    : IFilmsStore
{
    private readonly ILogger<FilmsStore> _logger;
    private readonly ISWAPIClient _client;

    public FilmsStore(ILogger<FilmsStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    public async Task<Film?> FetchAsync(FilmId id, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var request = id.ToRequest();
            var response = await this._client.Films.RetrieveAsync(request, cancellation);
            return response.ToModel();
        }
        catch (SWAPIClientNotFoundException)
        {
            return null;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to fetch Film {filmId}.", id.Value);
            throw new FilmsStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }
}
