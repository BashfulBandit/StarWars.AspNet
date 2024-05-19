using System.Text.Json.Serialization;

namespace SWApiClient.Models;

/// <summary>
/// A Starship resource is a single transport craft that has hyperdrive
/// capability.
/// </summary>
public class Starship
{
    /// <summary>
    /// The name of this starship. The common name, such as "Death Star".
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The model or official name of this starship. Such as "T-65 X-wing" or
    /// "DS-1 Orbital Battle Station".
    /// </summary>
    public string Model { get; set; } = default!;

    /// <summary>
    /// The class of this starship, such as "Starfighter" or "Deep Space Mobile
    /// Battlestation"
    /// </summary>
    [JsonPropertyName("starship_class")]
    public string StarshipClass { get; set; } = default!;

    /// <summary>
    /// The manufacturer of this starship. Comma separated if more than one.
    /// </summary>
    public string Manufacturer { get; set; } = default!;

    /// <summary>
    /// The cost of this starship new, in galactic credits.
    /// </summary>
    [JsonPropertyName("cost_in_credits")]
    public string CostInCredits { get; set; } = default!;

    /// <summary>
    /// The length of this starship in meters.
    /// </summary>
    public string Length { get; set; } = default!;

    /// <summary>
    /// The number of personnel needed to run or pilot this starship.
    /// </summary>
    public string Crew { get; set; } = default!;

    /// <summary>
    /// The number of non-essential people this starship can transport.
    /// </summary>
    public string Passengers { get; set; } = default!;

    /// <summary>
    /// The maximum speed of this starship in the atmosphere. "N/A" if this
    /// starship is incapable of atmospheric flight.
    /// </summary>
    [JsonPropertyName("max_atmosphering_speed")]
    public string MaxAtmospheringSpeed { get; set; } = default!;

    /// <summary>
    /// The class of this starships hyperdrive.
    /// </summary>
    [JsonPropertyName("hyperdrive_rating")]
    public string HyperdriveRating { get; set; } = default!;

    /// <summary>
    /// The Maximum number of Megalights this starship can travel in a standard
    /// hour. A "Megalight" is a standard unit of distance and has never been
    /// defined before within the Star Wars universe. This figure is only really
    /// useful for measuring the difference in speed of starships. We can assume
    /// it is similar to AU, the distance between our Sun (Sol) and Earth.
    /// </summary>
    public string MGLT { get; set; } = default!;

    /// <summary>
    /// The maximum number of kilograms that this starship can transport.
    /// </summary>
    [JsonPropertyName("cargo_capacity")]
    public string CargoCapacity { get; set; } = default!;

    /// <summary>
    /// The maximum length of time that this starship can provide consumables
    /// for its entire crew without having to resupply.
    /// </summary>
    public string Consumables { get; set; } = default!;

    /// <summary>
    /// An array of Film URL Resources that this starship has appeared in.
    /// </summary>
    public IEnumerable<Uri> Films { get; set; } = default!;

    /// <summary>
    /// An array of People URL Resources that this starship has been piloted by.
    /// </summary>
    public IEnumerable<Uri> Pilots { get; set; } = default!;
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
