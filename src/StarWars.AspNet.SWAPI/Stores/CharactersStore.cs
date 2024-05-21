using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Extensions;
using StarWars.AspNet.SWAPI.Mappings.Characters;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;

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

    public async Task<IPage<Character>> ListAsync(CharactersSearchFilter filter, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            // Because of the way I designed the resources for my API and the way
            // the SW API is designed, I needed to iterate over all the pages
            // for the SW API List Species endpoint. The `GetAllAsync` extension
            // handles that.
            var paginated = (await this._client.People.GetAllAsync(cancellation))
                .AsQueryable()
                .Filter(filter)
                .Sort(filter)
                .Paginate(filter.Page, filter.PageSize)
                .MapTo(s => s.ToModel());
            return paginated;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to list characters.");
            throw new SpeciesStoreException($"{nameof(this.ListAsync)} error.", ex);
        }
    }
}
