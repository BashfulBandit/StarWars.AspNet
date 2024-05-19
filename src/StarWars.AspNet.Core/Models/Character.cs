using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Model of a character in the Star Wars universe.
/// </summary>
public class Character
{
    /// <summary>
    /// The unique identifier of the person.
    /// </summary>
    public CharacterId Id { get; set; } = CharacterId.Default;

    /// <summary>
    /// The name of the character.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The height of the character.
    /// </summary>
    public string Height { get; set; } = default!;

    /// <summary>
    /// The mass of the character.
    /// </summary>
    public string Mass { get; set; } = default!;

    /// <summary>
    /// The hair color of the character.
    /// </summary>
    public string HairColor { get; set; } = default!;

    /// <summary>
    /// The skin color of the character.
    /// </summary>
    public string SkinColor { get; set; } = default!;

    /// <summary>
    /// The eye color of the character.
    /// </summary>
    public string EyeColor { get; set; } = default!;

    /// <summary>
    /// The year the character was born.
    /// </summary>
    public string BirthYear { get; set; } = default!;

    /// <summary>
    /// The gender of the character.
    /// </summary>
    public string Gender { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = default;

    /// <summary>
    /// The date and time this resource was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = default;
}
