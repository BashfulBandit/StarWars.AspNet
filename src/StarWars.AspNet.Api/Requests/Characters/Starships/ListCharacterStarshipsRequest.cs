namespace StarWars.AspNet.Api.Requests.Characters.Starships;

/// <summary>
/// Request to retrieve a paginated list of a starships a character has piloted.
/// </summary>
internal class ListCharacterStarshipsRequest
    : PageRequest
{
    /// <summary>
    /// The identifier for the target character.
    /// </summary>
    public string CharacterId { get; set; } = default!;
}
