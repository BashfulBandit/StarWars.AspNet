using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses.People.Starships;

public class ListPersonStarshipsResponse
    : PageResponse
{
    public IEnumerable<Starship> Starships { get; set; } = default!;
}
