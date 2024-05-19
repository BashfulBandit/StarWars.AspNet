using RestSharp;
using StarWars.AspNet.Client.Http.Extensions;
using StarWars.AspNet.Client.Http.Mappings.Episodes.Species;
using StarWars.AspNet.Client.Requests.Episodes.Species;
using StarWars.AspNet.Client.Responses.Episodes.Species;

namespace StarWars.AspNet.Client.Http;

/// <inheritdoc/>
internal class EpisodeSpeciesClient
    : IStarWarsClient.IEpisodesClient.ISpeciesClient
{
    public const string EpisodeSpeciesEndpoint = "/api/episodes/{episodeId}/species";

    private readonly RestClient _client;

    public EpisodeSpeciesClient(RestClient client)
    {
        this._client = client;
    }

    /// <inheritdoc/>
    public async Task<ListEpisodeSpeciesResponse> ListAsync(ListEpisodeSpeciesRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = request.ToRestRequest();
        var restResponse = await this._client.ExecuteAsync<ListEpisodeSpeciesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
