using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Planets;

internal static class PlanetMappers
{
    public static Planet ToModel(this Clients.Models.Planet planet)
        => new()
        {
            Id = PlanetId.From(planet.Url.ParseId()),
            Name = planet.Name,
            RotationPeriod = planet.RotationPeriod,
            OrbitalPeriod = planet.OrbitalPeriod,
            Diameter = planet.Diameter,
            Climate = planet.Climate,
            Gravity = planet.Gravity,
            Terrain = planet.Terrain,
            SurfaceWater = planet.SurfaceWater,
            Population = planet.Population.ParsePopulation(),
            CreatedAt = planet.Created,
            UpdatedAt = planet.Edited
        };

    public static ulong? ParsePopulation(this string populationStr)
    {
        if (ulong.TryParse(populationStr, out var population))
        {
            return population;
        }
        return null;
    }
}
