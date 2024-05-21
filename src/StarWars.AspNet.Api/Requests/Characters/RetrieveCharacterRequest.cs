namespace StarWars.AspNet.Api.Requests.Characters;

/// <summary>
/// Request to retrieve a character by an identifier.
/// </summary>
internal class RetrieveCharacterRequest
{
    /// <summary>
    /// The target identifier.
    /// </summary>
    public string CharacterId { get; set; } = default!;
}
