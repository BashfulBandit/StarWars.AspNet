using System.Text.Json.Serialization;

namespace SWApiClient.Models;

/// <summary>
/// A People resource is an individual person or character within the Star Wars
/// universe.
/// </summary>
public class Person
{
    /// <summary>
    /// The name of this person.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The height of the person in centimeters.
    /// </summary>
    public string Height { get; set; } = default!;

    /// <summary>
    /// The mass of the person in kilograms.
    /// </summary>
    public string Mass { get; set; } = default!;

    /// <summary>
    /// The hair color of this person. Will be "unknown" if not known or "n/a"
    /// if the person does not have hair.
    /// </summary>
    [JsonPropertyName("hair_color")]
    public string HairColor { get; set; } = default!;

    /// <summary>
    /// The skin color of this person.
    /// </summary>
    [JsonPropertyName("skin_color")]
    public string SkinColor { get; set; } = default!;

    /// <summary>
    /// The eye color of this person. Will be "unknown" if not known or "n/a" if
    /// the person does not have an eye.
    /// </summary>
    [JsonPropertyName("eye_color")]
    public string EyeColor { get; set; } = default!;

    /// <summary>
    /// The birth year of the person, using the in-universe standard of BBY or
    /// ABY - Before the Battle of Yavin or After the Battle of Yavin.
    /// The Battle of Yavin is a battle that occurs at the end of Star Wars
    /// episode IV: A New Hope.
    /// </summary>
    [JsonPropertyName("birth_year")]
    public string BirthYear { get; set; } = default!;

    /// <summary>
    /// The gender of this person. Either "Male", "Female" or "unknown", "n/a"
    /// if the person does not have a gender.
    /// </summary>
    public string Gender { get; set; } = default!;

    /// <summary>
    /// The URL of a planet resource, a planet that this person was born on or
    /// inhabits.
    /// </summary>
    public Uri Homeworld { get; set; } = default!;

    /// <summary>
    /// An array of film resource URLs that this person has been in.
    /// </summary>
    public IEnumerable<Uri> Films { get; set; } = default!;

    /// <summary>
    /// An array of species resource URLs that this person belongs to.
    /// </summary>
    public IEnumerable<Uri> Species { get; set; } = default!;

    /// <summary>
    /// An array of vehicle resource URLs that this person has piloted.
    /// </summary>
    public IEnumerable<Uri> Vehicles { get; set; } = default!;

    /// <summary>
    /// An array of starship resource URLs that this person has piloted.
    /// </summary>
    public IEnumerable<Uri> Starships { get; set; } = default!;

    /// <summary>
    /// The hypermedia URL of this resource.
    /// </summary>
    public Uri Url { get; set; } = default!;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was created.
    /// </summary>
    public DateTime Created { get; set; } = default;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was edited.
    /// </summary>
    public DateTime Edited { get; set; } = default;
}
