using RestSharp;
using StarWars.AspNet.Client.Http.Extensions;
using StarWars.AspNet.Client.Http.Mappings.Characters;
using StarWars.AspNet.Client.Requests.Characters;
using StarWars.AspNet.Client.Responses.Characters;

namespace StarWars.AspNet.Client.Http;

/// <inheritdoc/>
internal class CharactersClient
    : IStarWarsClient.ICharactersClient
{
    public const string CharactersEndpoint = "/api/characters";

    private readonly RestClient _client;

    public CharactersClient(RestClient client)
    {
        this._client = client;

        this.Starships = new CharacterStarshipsClient(this._client);
    }

    /// <inheritdoc/>
    public IStarWarsClient.ICharactersClient.IStarshipsClient Starships { get; }

    public async Task<ListCharactersResponse> ListAsync(ListCharactersRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        request ??= new();
        var restRequest = request.ToRestRequest();
        var restResponse = await this._client.ExecuteAsync<ListCharactersResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
