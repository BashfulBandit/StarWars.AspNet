using RestSharp;
using StarWars.AspNet.Client.Http.Extensions;
using StarWars.AspNet.Client.Http.Mappings.Episodes;
using StarWars.AspNet.Client.Requests.Episodes;
using StarWars.AspNet.Client.Responses.Episodes;

namespace StarWars.AspNet.Client.Http;

/// <inheritdoc/>
internal class EpisodesClient
    : IStarWarsClient.IEpisodesClient
{
    public const string EpisodesEndpoint = "/api/episodes";
    public const string EpisodeEndpoint = "/api/episodes/{episodeId}";

    private readonly RestClient _client;

    public EpisodesClient(RestClient client)
    {
        this._client = client;

        this.Species = new EpisodeSpeciesClient(this._client);
    }

    /// <inheritdoc/>
    public IStarWarsClient.IEpisodesClient.ISpeciesClient Species { get; }

    public async Task<ListEpisodesResponse> ListAsync(ListEpisodesRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        request ??= new();
        var restRequest = request.ToRestRequest();
        var restResponse = await this._client.ExecuteAsync<ListEpisodesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }

    public async Task<RetrieveEpisodeResponse> RetrieveAsync(RetrieveEpisodeRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = request.ToRestRequest();
        var restResponse = await this._client.ExecuteAsync<RetrieveEpisodeResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
