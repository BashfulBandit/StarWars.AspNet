using System.Text.Json.Serialization;

namespace SWApiClient.Models;

/// <summary>
/// A Vehicle resource is a single transport craft that does not have hyperdrive
/// capability.
/// </summary>
public class Vehicle
{
    /// <summary>
    /// The name of this vehicle. The common name, such as "Sand Crawler" or
    /// "Speeder bike".
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The model or official name of this vehicle. Such as
    /// "All-Terrain Attack Transport".
    /// </summary>
    public string Model { get; set; } = default!;

    /// <summary>
    /// The class of this vehicle, such as "Wheeled" or "Repulsorcraft".
    /// </summary>
    [JsonPropertyName("vehicle_class")]
    public string VehicleClass { get; set; } = default!;

    /// <summary>
    /// The manufacturer of this vehicle. Comma separated if more than one.
    /// </summary>
    public string Manufacturer { get; set; } = default!;

    /// <summary>
    /// The length of this vehicle in meters.
    /// </summary>
    public string Length { get; set; } = default!;

    /// <summary>
    /// The cost of this vehicle new, in Galactic Credits.
    /// </summary>
    [JsonPropertyName("cost_in_credits")]
    public string CostInCredits { get; set; } = default!;

    /// <summary>
    /// The number of personnel needed to run or pilot this vehicle.
    /// </summary>
    public string Crew { get; set; } = default!;

    /// <summary>
    /// The number of non-essential people this vehicle can transport.
    /// </summary>
    public string Passengers { get; set; } = default!;

    /// <summary>
    /// The maximum speed of this vehicle in the atmosphere.
    /// </summary>
    [JsonPropertyName("max_atmosphering_speed")]
    public string MaxAtmospheringSpeed { get; set; } = default!;

    /// <summary>
    /// The maximum number of kilograms that this vehicle can transport.
    /// </summary>
    [JsonPropertyName("cargo_capacity")]
    public string CargoCapacity { get; set; } = default!;

    /// <summary>
    /// The maximum length of time that this vehicle can provide consumables for
    /// its entire crew without having to resupply.
    /// </summary>
    public string Consumables { get; set; } = default!;

    /// <summary>
    /// An array of Film URL Resources that this vehicle has appeared in.
    /// </summary>
    public IEnumerable<Uri> Films { get; set; } = default!;

    /// <summary>
    /// An array of People URL Resources that this vehicle has been piloted by.
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
