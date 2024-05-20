using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Api.Models;

/// <summary>
/// Model of a character in the Star Wars universe.
/// </summary>
public class CharacterDto
{
    /// <summary>
    /// The unique identifier of the person.
    /// </summary>
    public string Id { get; set; } = default!;

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

internal static class CharacterDtoExtensions
{
    public static CharacterDto ToDto(this Character model)
        => new()
        {
            Id = model.Id.Value,
            Name = model.Name,
            Height = model.Height,
            Mass = model.Mass,
            HairColor = model.HairColor,
            SkinColor = model.SkinColor,
            EyeColor = model.EyeColor,
            BirthYear = model.BirthYear,
            Gender = model.Gender,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
}
