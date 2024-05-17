using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Responses.Planets;

/// <summary>
/// Get all the planet resources.
/// </summary>
internal class ListPlanetsResponse
    : PageResponse<Planet>
{ }
