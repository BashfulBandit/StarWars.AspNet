using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Characters.Starships;

/// <summary>
/// Response from a successful request to retrieve a paginated list of starships
/// a character has piloted.
/// </summary>
internal class ListCharacterStarshipsResponse
    : PageResponse
{
    /// <summary>
    /// The paginated list of starships retrieved.
    /// </summary>
    public IEnumerable<StarshipDto> Starships { get; init; } = default!;
}
