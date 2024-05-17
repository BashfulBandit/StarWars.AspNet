namespace StarWars.AspNet.Client.Requests.People.Starships;

public class ListPersonStarshipsRequest
    : PageRequest
{
    public string PersonId { get; set; } = default!;
}
