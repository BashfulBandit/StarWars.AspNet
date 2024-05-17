using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.Vehicles;

/// <summary>
/// Model encapsulating data to make a request to retrieve a list of <see cref="Starship"/>.
/// </summary>
internal class ListVehiclesRequest
    : PageRequest
{ }
