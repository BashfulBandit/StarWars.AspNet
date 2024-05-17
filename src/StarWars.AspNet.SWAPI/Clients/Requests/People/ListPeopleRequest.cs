using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.People;

/// <summary>
/// Model encapsulating data to make a request to retrieve a list of <see cref="Person"/>.
/// </summary>
internal class ListPeopleRequest
    : PageRequest
{ }
