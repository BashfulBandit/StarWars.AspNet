using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Responses.People;

/// <summary>
/// Get all the people resources.
/// </summary>
internal class ListPeopleResponse
    : PageResponse<Person>
{ }
