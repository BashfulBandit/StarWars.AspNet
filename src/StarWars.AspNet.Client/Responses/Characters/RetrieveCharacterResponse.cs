using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses.Characters;

/// <summary>
/// A response representing a successful request to retrieve an <see cref="Models.Character"/>
/// by it's identifier.
/// </summary>
public class RetrieveCharacterResponse
{
    /// <summary>
    /// The retrieved character.
    /// </summary>
    public Character Character { get; set; } = default!;
}
