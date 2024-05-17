using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.Films;

/// <summary>
/// Model encapsulating data to make a request to retrieve a list of <see cref="Film"/>.
/// </summary>
internal class ListFilmsRequest
    : PageRequest
{ }
