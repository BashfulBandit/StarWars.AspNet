using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Episodes.Species;

/// <summary>
/// Response from a successful request to retrieve a paginated list of species
/// in a Star Wars episode.
/// </summary>
internal class ListEpisodeSpeciesResponse
    : PageResponse
{
    /// <summary>
    /// The paginated list of species retrieved.
    /// </summary>
    public IEnumerable<SpeciesDto> Species { get; init; } = default!;
}
