using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.Episodes;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Stores;

/// <inheritdoc />
internal class EpisodesStore
    : IEpisodesStore
{
    private readonly ILogger<EpisodesStore> _logger;
    private readonly ISWAPIClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="EpisodesStore"/>.
    /// </summary>
    public EpisodesStore(ILogger<EpisodesStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<Episode?> FetchAsync(EpisodeId id, CancellationToken cancellation = default)
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
            this._logger.LogDebug(ex, "Failed to fetch Episode {episodeId}.", id.Value);
            throw new EpisodesStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }

    public async Task<IPage<Episode>> ListAsync(EpisodesSearchFilter filter, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            // Because of the way I designed the resources for my API and the way
            // the SW API is designed, I needed to iterate over all the pages
            // for the SW API List Species endpoint. The `GetAllAsync` extension
            // handles that.
            var paginated = (await this._client.Films.GetAllAsync(cancellation))
                .AsQueryable()
                .Filter(filter)
                .Sort(filter)
                .Paginate(filter.Page, filter.PageSize)
                .MapTo(s => s.ToModel());
            return paginated;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to list Episodes.");
            throw new SpeciesStoreException($"{nameof(this.ListAsync)} error.", ex);
        }
    }
}
