using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses.Characters;

/// <summary>
/// 
/// </summary>
public class RetrieveCharacterResponse
{
    /// <summary>
    /// The retrieved character.
    /// </summary>
    public Character Character { get; set; } = default!;
}
