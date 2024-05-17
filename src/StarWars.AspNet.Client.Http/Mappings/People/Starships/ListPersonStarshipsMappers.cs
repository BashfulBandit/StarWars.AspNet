using RestSharp;
using StarWars.AspNet.Client.Requests.People.Starships;

namespace StarWars.AspNet.Client.Http.Mappings.People.Starships;

internal static class ListPersonStarshipsMappers
{
    public static RestRequest ToRestRequest(this ListPersonStarshipsRequest request)
        => new RestRequest(PersonStarshipsClient.PersonStarshipsEndpoint, Method.Get)
            .AddUrlSegment("personId", request.PersonId)
            .AddQueryParameters(request);
}
