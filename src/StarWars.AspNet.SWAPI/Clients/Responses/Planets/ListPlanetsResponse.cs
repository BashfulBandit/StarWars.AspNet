using SWApiClient.Models;

namespace SWApiClient.Responses.Planets;

/// <summary>
/// Get all the planet resources.
/// </summary>
public class ListPlanetsResponse
    : PageResponse<Planet>
{ }
