using RestSharp;

namespace StarWars.AspNet.Client.Http;

/// <inheritdoc/>
internal class EpisodesClient
    : IStarWarsClient.IEpisodesClient
{
    private readonly RestClient _client;

    public EpisodesClient(RestClient client)
    {
        this._client = client;

        this.Species = new EpisodeSpeciesClient(this._client);
    }

    /// <inheritdoc/>
    public IStarWarsClient.IEpisodesClient.ISpeciesClient Species { get; }
}
