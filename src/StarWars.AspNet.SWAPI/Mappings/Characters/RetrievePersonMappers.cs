using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using SWApiClient.Models;
using SWApiClient.Requests.People;
using SWApiClient.Responses.People;

namespace StarWars.AspNet.SWAPI.Mappings.Characters;

internal static class RetrievePersonMappers
{
    public static RetrievePersonRequest ToRequest(this CharacterId id)
        => new()
        {
            PersonId = id.Value
        };

    public static Character ToModel(this RetrievePersonResponse response)
        => (response as Person).ToModel();
}
