namespace StarWars.AspNet.Client.Requests.Characters.Starships;

/// <summary>
/// A request to retrieve a paginated list of <see cref="Models.Starship"/>
/// for a character in the Star Wars API.
/// </summary>
public class ListCharacterStarshipsRequest
    : PageRequest
{
    /// <summary>
    /// The identifier of the target character.
    /// </summary>
    public string CharacterId { get; set; } = default!;
}
