using RestSharp;

namespace StarWars.AspNet.Client.Http;

internal class PeopleClient
    : IStarWarsClient.IPeopleClient
{
    private readonly RestClient _client;

    public PeopleClient(RestClient client)
    {
        this._client = client;

        this.Starships = new PersonStarshipsClient(this._client);
    }

    public IStarWarsClient.IPeopleClient.IStarshipsClient Starships { get; }
}
