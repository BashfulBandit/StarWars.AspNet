using RestSharp;

namespace StarWars.AspNet.Client.Http;

/// <inheritdoc/>
internal class CharactersClient
    : IStarWarsClient.ICharactersClient
{
    private readonly RestClient _client;

    public CharactersClient(RestClient client)
    {
        this._client = client;

        this.Starships = new CharacterStarshipsClient(this._client);
    }

    /// <inheritdoc/>
    public IStarWarsClient.ICharactersClient.IStarshipsClient Starships { get; }
}
