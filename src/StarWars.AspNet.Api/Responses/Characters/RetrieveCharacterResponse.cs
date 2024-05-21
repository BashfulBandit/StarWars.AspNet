using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses.Characters;

/// <summary>
/// Response from a successful request to retrieve a Star Wars character by
/// identifier.
/// </summary>
internal class RetrieveCharacterResponse
{
    /// <summary>
    /// The retrieved Star Wars character identified by the provided identifer.
    /// </summary>
    public CharacterDto Character { get; set; } = default!;
}
