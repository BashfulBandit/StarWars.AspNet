using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Characters;
using StarWars.AspNet.Api.Responses.Characters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Queries.Characters;

namespace StarWars.AspNet.Api.Mappings.Characters;

internal static class RetrieveCharacterMappers
{
    public static FetchCharacterById ToQuery(this RetrieveCharacterRequest request)
        => FetchCharacterById.ToQuery(CharacterId.From(request.CharacterId));

    public static RetrieveCharacterResponse ToResponse(this FetchCharacterByIdResult result)
        => new()
        {
            Character = result.Character!.ToDto()
        };
}
