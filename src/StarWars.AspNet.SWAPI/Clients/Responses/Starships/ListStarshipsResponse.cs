using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Responses.Starships;

/// <summary>
/// Get all the starship resources.
/// </summary>
internal class ListStarshipsResponse
    : PageResponse<Starship>
{ }
