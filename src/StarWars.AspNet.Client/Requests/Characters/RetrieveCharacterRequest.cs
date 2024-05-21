namespace StarWars.AspNet.Client.Requests.Characters;

/// <summary>
/// A request to retrieve a <see cref="Models.Character"/> by identifer.
/// </summary>
public class RetrieveCharacterRequest
{
    /// <summary>
    /// The target identifier.
    /// </summary>
    public string CharacterId { get; set; } = default!;
}
