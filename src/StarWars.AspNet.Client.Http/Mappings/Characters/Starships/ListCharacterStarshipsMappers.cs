using RestSharp;
using StarWars.AspNet.Client.Requests.Characters.Starships;

namespace StarWars.AspNet.Client.Http.Mappings.Characters.Starships;

internal static class ListCharacterStarshipsMappers
{
    public static RestRequest ToRestRequest(this ListCharacterStarshipsRequest request)
        => new RestRequest(CharacterStarshipsClient.CharacterStarshipsEndpoint, Method.Get)
            .AddUrlSegment("characterId", request.CharacterId)
            .AddQueryParameters(request);
}
