using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Model of a species in the Star Wars universe.
/// </summary>
public class Species
{
    /// <summary>
    /// The unique identifier of the species.
    /// </summary>
    public SpeciesId Id { get; set; } = SpeciesId.Default;

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
    public ICollection<string> EyeColors { get; set; } = default!;

    /// <summary>
    /// A collection of hair colors present within the species.
    /// </summary>
    public ICollection<string> HairColors { get; set; } = default!;

    /// <summary>
    /// A collection of skin colors present within the species.
    /// </summary>
    public ICollection<string> SkinColors { get; set; } = default!;

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
