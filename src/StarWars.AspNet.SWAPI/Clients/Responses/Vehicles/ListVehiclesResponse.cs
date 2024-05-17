using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Responses.Vehicles;

/// <summary>
/// Get all the vehicle resources.
/// </summary>
internal class ListVehiclesResponse
    : PageResponse<Vehicle>
{ }
