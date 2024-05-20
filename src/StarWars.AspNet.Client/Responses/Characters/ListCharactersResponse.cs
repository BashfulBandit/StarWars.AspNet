using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses.Characters;

/// <summary>
/// A response representing a successful request to the Star Wars API to get a
/// filterd, sorted, and paginated list of <see cref="Character"/>.
/// </summary>
public class ListCharactersResponse
    : PageResponse
{
    /// <summary>
    /// The retrieved page of <see cref="Character"/>.
    /// </summary>
    public IEnumerable<Character> Characters { get; set; } = default!;
}
