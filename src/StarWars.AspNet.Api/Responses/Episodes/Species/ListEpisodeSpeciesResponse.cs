using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Episodes.Species;

internal class ListEpisodeSpeciesResponse
    : PageResponse
{
    public IEnumerable<SpeciesDto> Species { get; init; } = default!;
}
