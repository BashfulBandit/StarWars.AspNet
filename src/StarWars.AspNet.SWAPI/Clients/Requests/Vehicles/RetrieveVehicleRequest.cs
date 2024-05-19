using SWApiClient.Models;

namespace SWApiClient.Requests.Vehicles;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Starship"/>.
/// </summary>
public class RetrieveVehicleRequest
{
    /// <summary>
    /// The StarWars API identifier for the vehicle.
    /// </summary>
    public string VehicleId { get; set; } = default!;
}
