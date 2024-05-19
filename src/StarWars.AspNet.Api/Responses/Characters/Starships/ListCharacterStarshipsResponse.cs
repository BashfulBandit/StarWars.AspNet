using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Characters.Starships;

/// <summary>
/// 
/// </summary>
internal class ListCharacterStarshipsResponse
    : PageResponse
{
    public IEnumerable<StarshipDto> Starships { get; init; } = default!;
}
