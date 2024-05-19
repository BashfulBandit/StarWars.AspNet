using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Planets;

internal static class PlanetMappers
{
    public static Planet ToModel(this SWApiClient.Models.Planet planet)
        => new()
        {
            Id = PlanetId.From(planet.Url.ParseId()),
            Name = planet.Name,
            RotationPeriod = planet.RotationPeriod,
            OrbitalPeriod = planet.OrbitalPeriod,
            Diameter = planet.Diameter,
            Climates = planet.Climate.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Gravity = planet.Gravity,
            Terrains = planet.Terrain.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
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
