using SWApiClient.Models;

namespace SWApiClient.Requests.Planets;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Planet"/>.
/// </summary>
public class RetrievePlanetRequest
{
    /// <summary>
    /// The StarWars API identifier for the planet.
    /// </summary>
    public string PlanetId { get; set; } = default!;
}
