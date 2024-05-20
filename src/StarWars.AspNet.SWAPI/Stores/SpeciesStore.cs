using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Extensions;
using StarWars.AspNet.SWAPI.Mappings.Species;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;

namespace StarWars.AspNet.SWAPI.Stores;

/// <inheritdoc />
internal class SpeciesStore
    : ISpeciesStore
{
    private readonly ILogger<SpeciesStore> _logger;
    private readonly ISWAPIClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpeciesStore"/>.
    /// </summary>
    public SpeciesStore(ILogger<SpeciesStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    /// <inheritdoc />
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
            throw new SpeciesStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<IPage<Species>> ListAsync(SpeciesSearchFilter filter, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            // Because of the way I designed the resources for my API and the way
            // the SW API is designed, I needed to iterate over all the pages
            // for the SW API List Species endpoint. The `GetAllAsync` extension
            // handles that.
            var paginated = (await this._client.Species.GetAllAsync(cancellation))
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
            throw new SpeciesStoreException($"{nameof(this.ListAsync)} error.", ex);
        }
    }
}
