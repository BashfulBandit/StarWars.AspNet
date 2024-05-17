using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.Planets;

namespace StarWars.AspNet.SWAPI.Stores;

internal class PlanetsStore
    : IPlanetsStore
{
    private readonly ILogger<PlanetsStore> _logger;
    private readonly ISWAPIClient _client;

    public PlanetsStore(ILogger<PlanetsStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    public async Task<Planet?> FetchAsync(PlanetId id, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var request = id.ToRequest();
            var response = await this._client.Planets.RetrieveAsync(request, cancellation);
            return response.ToModel();
        }
        catch (SWAPIClientNotFoundException)
        {
            return null;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to fetch Planet {planetId}.", id.Value);
            throw new PlanetsStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }

    public async Task<IPage<Planet>> ListAsync(PlanetsSearchFilter filter, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var request = filter.ToRequest();
            var response = await this._client.Planets.ListAsync(request, cancellation);
            return response.ToModel();
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to list Planets.");
            throw new PlanetsStoreException($"{nameof(this.ListAsync)} error.", ex);
        }
    }
}
