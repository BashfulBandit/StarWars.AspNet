using System.Text.Json.Serialization;

namespace SWApiClient.Models;

/// <summary>
/// A Planet resource is a large mass, planet or planetoid in the Star Wars
/// Universe, at the time of 0 ABY.
/// </summary>
public class Planet
{
    /// <summary>
    /// The name of this planet.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The number of standard hours it takes for this planet to complete a
    /// single rotation on its axis.
    /// </summary>
    [JsonPropertyName("rotation_period")]
    public string RotationPeriod { get; set; } = default!;

    /// <summary>
    /// The number of standard days it takes for this planet to complete a
    /// single orbit of its local star.
    /// </summary>
    [JsonPropertyName("orbital_period")]
    public string OrbitalPeriod { get; set; } = default!;

    /// <summary>
    /// The diameter of this planet in kilometers.
    /// </summary>
    public string Diameter { get; set; } = default!;

    /// <summary>
    /// The climate of this planet. Comma separated if diverse.
    /// </summary>
    public string Climate { get; set; } = default!;

    /// <summary>
    /// A number denoting the gravity of this planet, where "1" is normal or 1
    /// standard G. "2" is twice or 2 standard Gs. "0.5" is half or 0.5 standard
    /// Gs.
    /// </summary>
    public string Gravity { get; set; } = default!;

    /// <summary>
    /// The terrain of this planet. Comma separated if diverse.
    /// </summary>
    public string Terrain { get; set; } = default!;

    /// <summary>
    /// The percentage of the planet surface that is naturally occurring water
    /// or bodies of water.
    /// </summary>
    [JsonPropertyName("surface_water")]
    public string SurfaceWater { get; set; } = default!;

    /// <summary>
    /// The average population of sentient beings inhabiting this planet.
    /// </summary>
    public string Population { get; set; } = default!;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was created.
    /// </summary>
    public DateTime Created { get; set; } = default;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was edited.
    /// </summary>
    public DateTime Edited { get; set; } = default;

    /// <summary>
    /// An array of People URL Resources that live on this planet.
    /// </summary>
    public IEnumerable<Uri> Residents { get; set; } = default!;

    /// <summary>
    /// An array of Film URL Resources that this planet has appeared in.
    /// </summary>
    public IEnumerable<Uri> Films { get; set; } = default!;

    /// <summary>
    /// The hypermedia URL of this resource.
    /// </summary>
    public Uri Url { get; set; } = default!;
}
