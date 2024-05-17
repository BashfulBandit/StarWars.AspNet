using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Responses.Films;

/// <summary>
/// Get all the film resources.
/// </summary>
internal class ListFilmsResponse
    : PageResponse<Film>
{ }
