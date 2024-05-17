using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.Vehicles;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Starship"/>.
/// </summary>
internal class RetrieveVehicleRequest
{
    /// <summary>
    /// The StarWars API identifier for the vehicle.
    /// </summary>
    public string VehicleId { get; set; } = default!;
}
