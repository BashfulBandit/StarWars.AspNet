namespace StarWars.AspNet.Client.Requests.Episodes.Species;

public class ListEpisodeSpeciesRequest
    : PageRequest
{
    public string EpisodeId { get; set; } = default!;
}

