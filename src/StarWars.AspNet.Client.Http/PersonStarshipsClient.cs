using RestSharp;
using StarWars.AspNet.Client.Http.Extensions;
using StarWars.AspNet.Client.Http.Mappings.People.Starships;
using StarWars.AspNet.Client.Requests.People.Starships;
using StarWars.AspNet.Client.Responses.People.Starships;

namespace StarWars.AspNet.Client.Http;

public class PersonStarshipsClient
    : IStarWarsClient.IPeopleClient.IStarshipsClient
{
    public const string PersonStarshipsEndpoint = "/api/people/{personId}/starships";

    private readonly RestClient _client;

    public PersonStarshipsClient(RestClient client)
    {
        this._client = client;
    }

    public async Task<ListPersonStarshipsResponse> ListAsync(ListPersonStarshipsRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = request.ToRestRequest();
        var restResponse = await this._client.ExecuteAsync<ListPersonStarshipsResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
