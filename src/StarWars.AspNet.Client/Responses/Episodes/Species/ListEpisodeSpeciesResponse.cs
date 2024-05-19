namespace StarWars.AspNet.Client.Responses.Episodes.Species;

/// <summary>
/// A response representing a successful request to the Star Wars API to get a
/// filtered, sorted, and paginated list of <see cref="Models.Species"/> for an
/// episode.
/// </summary>
public class ListEpisodeSpeciesResponse
    : PageResponse
{
    /// <summary>
    /// The retrieved page of <see cref="Models.Species"/>.
    /// </summary>
    public IEnumerable<Models.Species> Species { get; set; } = default!;
}
