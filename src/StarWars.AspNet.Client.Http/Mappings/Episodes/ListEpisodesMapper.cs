using RestSharp;
using StarWars.AspNet.Client.Requests.Episodes;

namespace StarWars.AspNet.Client.Http.Mappings.Episodes;

internal static class ListEpisodesMapper
{
    public static RestRequest ToRestRequest(this ListEpisodesRequest request)
        => new RestRequest(EpisodesClient.EpisodesEndpoint, Method.Get)
            .AddQueryParameters(request);
}
