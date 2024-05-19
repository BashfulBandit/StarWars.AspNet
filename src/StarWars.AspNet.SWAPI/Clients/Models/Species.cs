using System.Text.Json.Serialization;

namespace SWApiClient.Models;

/// <summary>
/// A Species resource is a type of person or character within the Star Wars
/// Universe.
/// </summary>
public class Species
{
    /// <summary>
    /// The name of this species.
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
    [JsonPropertyName("average_height")]
    public string AverageHeight { get; set; } = default!;

    /// <summary>
    /// The average lifespan of this species in years.
    /// </summary>
    [JsonPropertyName("average_lifespan")]
    public string AverageLifespan { get; set; } = default!;

    /// <summary>
    /// A comma-separated string of common eye colors for this species, "none"
    /// if this species does not typically have eyes.
    /// </summary>
    [JsonPropertyName("eye_colors")]
    public string EyeColors { get; set; } = default!;

    /// <summary>
    /// A comma-separated string of common hair colors for this species, "none"
    /// if this species does not typically have hair.
    /// </summary>
    [JsonPropertyName("hair_colors")]
    public string HairColors { get; set; } = default!;

    /// <summary>
    /// A comma-separated string of common skin colors for this species, "none"
    /// if this species does not typically have skin.
    /// </summary>
    [JsonPropertyName("skin_colors")]
    public string SkinColors { get; set; } = default!;

    /// <summary>
    /// The language commonly spoken by this species.
    /// </summary>
    public string Language { get; set; } = default!;

    /// <summary>
    /// The URL of a planet resource, a planet that this species originates
    /// from.
    /// </summary>
    public Uri Homeworld { get; set; } = default!;

    /// <summary>
    /// An array of People URL Resources that are a part of this species.
    /// </summary>
    public IEnumerable<Uri> People { get; set; } = default!;

    /// <summary>
    /// An array of Film URL Resources that this species has appeared in.
    /// </summary>
    public IEnumerable<Uri> Films { get; set; } = default!;

    /// <summary>
    /// The hypermedia URL of this resource.
    /// </summary>
    public Uri Url { get; set; } = default!;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was created.
    /// </summary>
    public DateTime Created { get; set; } = default!;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was edited.
    /// </summary>
    public DateTime Edited { get; set; } = default!;
}
