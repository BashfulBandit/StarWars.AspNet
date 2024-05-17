using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Clients.Requests.People;
using StarWars.AspNet.SWAPI.Clients.Responses.People;

namespace StarWars.AspNet.SWAPI.Mappings.People;

internal static class RetrievePersonMappers
{
    public static RetrievePersonRequest ToRequest(this PersonId id)
        => new()
        {
            PersonId = id.Value
        };

    public static Person ToModel(this RetrievePersonResponse response)
        => (response as Clients.Models.Person).ToModel();
}
