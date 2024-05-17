using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.Planets;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Planet"/>.
/// </summary>
internal class RetrievePlanetRequest
{
    /// <summary>
    /// The StarWars API identifier for the planet.
    /// </summary>
    public string PlanetId { get; set; } = default!;
}
