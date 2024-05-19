using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using SWApiClient.Requests.Starships;
using SWApiClient.Responses.Starships;

namespace StarWars.AspNet.SWAPI.Mappings.Starships;

internal static class RetrieveStarshipMappers
{
    public static RetrieveStarshipRequest ToRequest(this StarshipId id)
        => new()
        {
            StarshipId = id.Value
        };

    public static Starship ToModel(this RetrieveStarshipResponse response)
        => (response as SWApiClient.Models.Starship).ToModel();
}
