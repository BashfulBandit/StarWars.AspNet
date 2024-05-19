using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.Episodes;

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
}
