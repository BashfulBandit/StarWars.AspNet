using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses.Characters.Starships;

/// <summary>
/// A response representing a successful request to the Star Wars API to get a
/// filtered, sorted, and paginated list of <see cref="Starship"/> for a
/// character.
/// </summary>
public class ListCharacterStarshipsResponse
    : PageResponse
{
    /// <summary>
    /// The retrieved page of <see cref="Starship"/>.
    /// </summary>
    public IEnumerable<Starship> Starships { get; set; } = default!;
}
