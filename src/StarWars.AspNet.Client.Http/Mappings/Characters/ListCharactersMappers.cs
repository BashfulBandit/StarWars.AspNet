using RestSharp;
using StarWars.AspNet.Client.Requests.Characters;

namespace StarWars.AspNet.Client.Http.Mappings.Characters;

internal static class ListCharactersMappers
{
    public static RestRequest ToRestRequest(this ListCharactersRequest request)
    {
        var restRequest = new RestRequest(CharactersClient.CharactersEndpoint, Method.Get)
            .AddQueryParameters(request);

        if (request.Name is not null)
        {
            restRequest = restRequest.AddQueryParameter("name", request.Name);
        }

        return restRequest;
    }
}
