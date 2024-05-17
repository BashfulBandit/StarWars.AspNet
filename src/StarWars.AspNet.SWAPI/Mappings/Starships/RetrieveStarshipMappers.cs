using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Clients.Requests.Starships;
using StarWars.AspNet.SWAPI.Clients.Responses.Starships;

namespace StarWars.AspNet.SWAPI.Mappings.Starships;

internal static class RetrieveStarshipMappers
{
    public static RetrieveStarshipRequest ToRequest(this StarshipId id)
        => new()
        {
            StarshipId = id.Value
        };

    public static Starship ToModel(this RetrieveStarshipResponse response)
        => (response as Clients.Models.Starship).ToModel();
}
