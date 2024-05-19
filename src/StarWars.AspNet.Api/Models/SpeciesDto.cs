using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Api.Models;

/// <summary>
/// DTO of a species in the Star Wars universe.
/// </summary>
internal class SpeciesDto
{
    /// <summary>
    /// The unique identifier of the species.
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// The name of the species.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The classification of this species, such as "mammal" or "reptile".
    /// </summary>
    public string Classification { get; set; } = default!;

    /// <summary>
    /// The designation of this species, such as "sentient".
    /// </summary>
    public string Designation { get; set; } = default!;

    /// <summary>
    /// The average height of this species in centimeters.
    /// </summary>
    public string AverageHeight { get; set; } = default!;

    /// <summary>
    /// The average lifespan of this species in years.
    /// </summary>
    public string AverageLifespan { get; set; } = default!;

    /// <summary>
    /// A collection of eye colors present within the species.
    /// </summary>
    public IEnumerable<string> EyeColors { get; set; } = default!;

    /// <summary>
    /// A collection of hair colors present within the species.
    /// </summary>
    public IEnumerable<string> HairColors { get; set; } = default!;

    /// <summary>
    /// A collection of skin colors present within the species.
    /// </summary>
    public IEnumerable<string> SkinColors { get; set; } = default!;

    /// <summary>
    /// The language commonly spoken by this species.
    /// </summary>
    public string Language { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = default;

    /// <summary>
    /// The date and time this resource was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = default;
}

internal static class SpeciesExtensions
{
    public static SpeciesDto ToDto(this Species model)
        => new()
        {
            Id = model.Id.Value,
            Name = model.Name,
            Classification = model.Classification,
            Designation = model.Designation,
            AverageHeight = model.AverageHeight,
            AverageLifespan = model.AverageLifespan,
            EyeColors = model.EyeColors,
            HairColors = model.HairColors,
            SkinColors = model.SkinColors,
            Language = model.Language,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
}
