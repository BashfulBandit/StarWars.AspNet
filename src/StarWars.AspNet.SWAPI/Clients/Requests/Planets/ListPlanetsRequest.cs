using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.Planets;

/// <summary>
/// Model encapsulating data to make a request to retrieve a list of <see cref="Planet"/>.
/// </summary>
internal class ListPlanetsRequest
    : PageRequest
{ }
