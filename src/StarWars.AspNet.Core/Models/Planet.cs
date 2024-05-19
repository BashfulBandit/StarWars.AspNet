using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Model of a planet in the Star Wars universe.
/// </summary>
public class Planet
{
    /// <summary>
    /// The unique identifier of the planet.
    /// </summary>
    public PlanetId Id { get; set; } = PlanetId.Default;

    /// <summary>
    /// The name of the planet.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The number of standard hours it takes for this planet to complete a
    /// single rotation on its axis.
    /// </summary>
    public string RotationPeriod { get; set; } = default!;

    /// <summary>
    /// The number of standard days it takes for this planet to complete a
    /// single orbit of its local star.
    /// </summary>
    public string OrbitalPeriod { get; set; } = default!;

    /// <summary>
    /// The diameter of this planet in kilometers.
    /// </summary>
    public string Diameter { get; set; } = default!;

    /// <summary>
    /// A collection of climates present on the planet.
    /// </summary>
    public ICollection<string> Climates { get; set; } = default!;

    /// <summary>
    /// A number denoting the gravity of this planet, where "1" is normal or 1
    /// standard G. "2" is twice or 2 standard Gs. "0.5" is half or 0.5 standard Gs.
    /// </summary>
    public string Gravity { get; set; } = default!;

    /// <summary>
    /// A collection of terrain present on the planet.
    /// </summary>
    public ICollection<string> Terrains { get; set; } = default!;

    /// <summary>
    /// The percentage of the planet surface that is naturally occurring water
    /// or bodies of water.
    /// </summary>
    public string SurfaceWater { get; set; } = default!;

    /// <summary>
    /// The average population of sentient beings inhabiting this planet.
    /// </summary>
    public ulong? Population { get; set; } = default;

    /// <summary>
    /// The date and time this resource was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = default!;
}
