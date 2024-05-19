using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using SWApiClient.Requests.Planets;
using SWApiClient.Responses.Planets;

namespace StarWars.AspNet.SWAPI.Mappings.Planets;

internal static class RetrievePlanetMappers
{
    public static RetrievePlanetRequest ToRequest(this PlanetId id)
        => new()
        {
            PlanetId = id.Value
        };

    public static Planet ToModel(this RetrievePlanetResponse response)
        => (response as SWApiClient.Models.Planet).ToModel();
}
