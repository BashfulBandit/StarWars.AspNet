using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.Species;

namespace StarWars.AspNet.SWAPI.Stores;

internal class SpeciesStore
    : ISpeciesStore
{
    private readonly ILogger<SpeciesStore> _logger;
    private readonly ISWAPIClient _client;

    public SpeciesStore(ILogger<SpeciesStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    public async Task<Species?> FetchAsync(SpeciesId id, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var request = id.ToRequest();
            var response = await this._client.Species.RetrieveAsync(request, cancellation);
            return response.ToModel();
        }
        catch (SWAPIClientNotFoundException)
        {
            return null;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to fetch Species {speciesId}.", id.Value);
            throw new EpisodesStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }
}
