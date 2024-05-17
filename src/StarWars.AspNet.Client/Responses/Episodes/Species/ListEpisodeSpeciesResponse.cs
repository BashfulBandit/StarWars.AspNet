namespace StarWars.AspNet.Client.Responses.Episodes.Species;

public class ListEpisodeSpeciesResponse
    : PageResponse
{
    public IEnumerable<Models.Species> Species { get; set; } = default!;
}
