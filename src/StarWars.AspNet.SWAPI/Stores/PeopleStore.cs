using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.People;

namespace StarWars.AspNet.SWAPI.Stores;

internal class PeopleStore
    : IPeopleStore
{
    private readonly ILogger<PeopleStore> _logger;
    private readonly ISWAPIClient _client;

    public PeopleStore(ILogger<PeopleStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    public async Task<Person?> FetchAsync(PersonId id, CancellationToken cancellation = default)
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
            throw new FilmsStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }
}
