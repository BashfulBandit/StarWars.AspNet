using RestSharp;
using StarWars.AspNet.Client.Http.Extensions;
using StarWars.AspNet.Client.Http.Mappings.People.Starships;
using StarWars.AspNet.Client.Requests.Characters.Starships;
using StarWars.AspNet.Client.Responses.Characters.Starships;

namespace StarWars.AspNet.Client.Http;

/// <inheritdoc/>
public class CharacterStarshipsClient
    : IStarWarsClient.ICharactersClient.IStarshipsClient
{
    public const string CharacterStarshipsEndpoint = "/api/characters/{characterId}/starships";

    private readonly RestClient _client;

    public CharacterStarshipsClient(RestClient client)
    {
        this._client = client;
    }

    /// <inheritdoc/>
    public async Task<ListCharacterStarshipsResponse> ListAsync(ListCharacterStarshipsRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = request.ToRestRequest();
        var restResponse = await this._client.ExecuteAsync<ListCharacterStarshipsResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
