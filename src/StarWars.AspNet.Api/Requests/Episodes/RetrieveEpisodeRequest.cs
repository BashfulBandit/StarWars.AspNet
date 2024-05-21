namespace StarWars.AspNet.Api.Requests.Episodes;

/// <summary>
/// Request to retrieve a episode by an identifier.
/// </summary>
internal class RetrieveEpisodeRequest
{
    /// <summary>
    /// The target identifier.
    /// </summary>
    public string EpisodeId { get; set; } = default!;
}
