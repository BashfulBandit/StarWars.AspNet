using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;
using StarWars.AspNet.SWAPI.Extensions;
using StarWars.AspNet.SWAPI.Mappings.Starships;

namespace StarWars.AspNet.SWAPI.Stores;

/// <inheritdoc />
internal class StarshipsStore
    : IStarshipsStore
{
    private readonly ILogger<StarshipsStore> _logger;
    private readonly ISWAPIClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="StarshipsStore"/>.
    /// </summary>
    public StarshipsStore(ILogger<StarshipsStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<Starship?> FetchAsync(StarshipId id, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var request = id.ToRequest();
            var response = await this._client.Starships.RetrieveAsync(request, cancellation);
            return response.ToModel();
        }
        catch (SWAPIClientNotFoundException)
        {
            return null;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to fetch Starship {starshipId}.", id.Value);
            throw new StarshipsStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<IPage<Starship>> ListAsync(StarshipsSearchFilter filter, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var paginated = (await this._client.Starships.GetAllAsync(cancellation))
                .AsQueryable()
                .Filter(filter)
                .Sort(filter)
                .Paginate(filter.Page, filter.PageSize)
                .MapTo(s => s.ToModel());
            return paginated;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to list Species.");
            throw new StarshipsStoreException($"{nameof(this.ListAsync)} error.", ex);
        }
    }
}
