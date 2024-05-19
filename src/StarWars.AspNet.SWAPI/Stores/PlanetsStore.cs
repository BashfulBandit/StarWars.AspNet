using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;
using StarWars.AspNet.SWAPI.Extensions;
using StarWars.AspNet.SWAPI.Mappings.Planets;

namespace StarWars.AspNet.SWAPI.Stores;

/// <inheritdoc />
internal class PlanetsStore
    : IPlanetsStore
{
    private readonly ILogger<PlanetsStore> _logger;
    private readonly ISWAPIClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlanetsStore"/>.
    /// </summary>
    public PlanetsStore(ILogger<PlanetsStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<IPage<Planet>> ListAsync(PlanetsSearchFilter filter, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var all = await this._client.Planets.GetAllAsync(cancellation);
            var filtered = all.AsQueryable().Filter(filter);
            var sorted = filtered.Sort(filter);
            var paginated = sorted.Paginate(filter.Page, filter.PageSize);
            var page = paginated.MapTo(p => p.ToModel());
            return page;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to list Planets.");
            throw new PlanetsStoreException($"{nameof(this.ListAsync)} error.", ex);
        }
    }
}
