namespace StarWars.AspNet.Api.Requests.Episodes;

/// <summary>
/// Reques to retrieve a paginated list of species on a Star Wars episode.
/// </summary>
internal class ListEpisodeSpeciesRequest
    : PageRequest
{
    public string EpisodeId { get; set; } = default!;
}
