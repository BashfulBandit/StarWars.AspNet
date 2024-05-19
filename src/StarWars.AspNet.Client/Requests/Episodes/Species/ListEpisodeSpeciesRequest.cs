namespace StarWars.AspNet.Client.Requests.Episodes.Species;

/// <summary>
/// A request to retrieve a paginated list of <see cref="Models.Species"/>
/// for aan episode in the Star Wars API.
/// </summary>
public class ListEpisodeSpeciesRequest
    : PageRequest
{
    /// <summary>
    /// The identifier of the target episode.
    /// </summary>
    public string EpisodeId { get; set; } = default!;
}

