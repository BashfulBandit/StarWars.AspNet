namespace StarWars.AspNet.Api.Requests.People.Starships;

internal class ListPersonStarshipsRequest
    : PageRequest
{
    public string PersonId { get; set; } = default!;
}
