using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses.Episodes;

/// <summary>
/// A response representing a successful request to the Star Wars API to get a
/// filterd, sorted, and paginated list of <see cref="Episode"/>.
/// </summary>
public class ListEpisodesResponse
    : PageResponse
{
    /// <summary>
    /// The retrieved page of <see cref="Episode"/>.
    /// </summary>
    public IEnumerable<Episode> Episodes { get; set; } = default!;
}
