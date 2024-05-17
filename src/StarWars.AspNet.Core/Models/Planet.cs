using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

public class Planet
{
    public PlanetId Id { get; set; } = PlanetId.Default;

    public string Name { get; set; } = default!;

    public string RotationPeriod { get; set; } = default!;

    public string OrbitalPeriod { get; set; } = default!;

    public string Diameter { get; set; } = default!;

    public string Climate { get; set; } = default!;

    public string Gravity { get; set; } = default!;

    public string Terrain { get; set; } = default!;

    public string SurfaceWater { get; set; } = default!;

    public ulong? Population { get; set; } = default;

    public DateTime CreatedAt { get; set; } = default;

    public DateTime UpdatedAt { get; set; } = default;
}
