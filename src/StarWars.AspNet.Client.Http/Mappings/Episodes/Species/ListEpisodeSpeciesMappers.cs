using RestSharp;
using StarWars.AspNet.Client.Requests.Episodes.Species;

namespace StarWars.AspNet.Client.Http.Mappings.Episodes.Species;

internal static class ListEpisodeSpeciesMappers
{
    public static RestRequest ToRestRequest(this ListEpisodeSpeciesRequest request)
        => new RestRequest(EpisodeSpeciesClient.EpisodeSpeciesEndpoint, Method.Get)
            .AddUrlSegment("episodeId", request.EpisodeId)
            .AddQueryParameters(request);
}
