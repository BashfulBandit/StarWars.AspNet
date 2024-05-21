using RestSharp;
using StarWars.AspNet.Client.Requests.Episodes;

namespace StarWars.AspNet.Client.Http.Mappings.Episodes;

internal static class RetrieveEpisodeMappers
{
    public static RestRequest ToRestRequest(this RetrieveEpisodeRequest request)
        => new RestRequest(EpisodesClient.EpisodeEndpoint, Method.Get)
            .AddUrlSegment("episodeId", request.EpisodeId);
}
