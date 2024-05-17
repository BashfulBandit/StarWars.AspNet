namespace StarWars.AspNet.Api.Requests.Episodes;

internal class ListEpisodeSpeciesRequest
    : PageRequest
{
    public string EpisodeId { get; set; } = default!;
}
