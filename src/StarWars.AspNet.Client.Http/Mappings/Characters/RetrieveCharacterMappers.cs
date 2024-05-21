using RestSharp;
using StarWars.AspNet.Client.Requests.Characters;

namespace StarWars.AspNet.Client.Http.Mappings.Characters;

internal static class RetrieveCharacterMappers
{
    public static RestRequest ToRestRequest(this RetrieveCharacterRequest request)
        => new RestRequest(CharactersClient.CharacterEndpoint, Method.Get)
            .AddUrlSegment("characterId", request.CharacterId);
}
