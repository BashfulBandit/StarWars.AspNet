using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses.Episodes;

/// <summary>
/// A response representing a successful request to retrieve an <see cref="Models.Episode"/>
/// by it's identifier.
/// </summary>
public class RetrieveEpisodeResponse
{
    /// <summary>
    /// The retrieved character.
    /// </summary>
    public Episode Episode { get; set; } = default!;
}
