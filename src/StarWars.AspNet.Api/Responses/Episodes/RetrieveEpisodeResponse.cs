using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Episodes;

/// <summary>
/// Response from a successful request to retrieve a Star Wars episode by
/// identifier.
/// </summary>
internal class RetrieveEpisodeResponse
{
    /// <summary>
    /// The retrieved Star Wars episode identified by the provided identifer.
    /// </summary>
    public EpisodeDto Episode { get; set; } = default!;
}
