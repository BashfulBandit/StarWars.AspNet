using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Episodes;

/// <summary>
/// Response from a successful request to retrieve a paginated list of episodes
/// from the Star Wars universe.
/// </summary>
internal class ListEpisodesResponse
    : PageResponse
{
    /// <summary>
    /// The paginated list of episodes retrieved.
    /// </summary>
    public IEnumerable<EpisodeDto> Episodes { get; set; } = default!;
}
