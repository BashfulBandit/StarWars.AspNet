using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.People.Starships;

internal class ListPersonStarshipsResponse
    : PageResponse
{
    public IEnumerable<StarshipDto> Starships { get; init; } = default!;
}
