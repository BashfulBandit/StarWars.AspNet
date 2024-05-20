using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Characters;

/// <summary>
/// Response from a successful request to retrieve a paginated list of characters
/// from the Star Wars universe.
/// </summary>
internal class ListCharactersResponse
    : PageResponse
{
    /// <summary>
    /// The paginated list of characters retrieved.
    /// </summary>
    public IEnumerable<CharacterDto> Characters { get; set; } = default!;
}
