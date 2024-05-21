namespace StarWars.AspNet.Client.Requests.Episodes;

/// <summary>
/// A request to retrieve a <see cref="Models.Episode"/> by identifer.
/// </summary>
public class RetrieveEpisodeRequest
{
    /// <summary>
    /// The target identifier.
    /// </summary>
    public string EpisodeId { get; set; } = default!;
}
