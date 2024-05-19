using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Model of a vehicle in the Star Wars universe.
/// </summary>
public class Vehicle
{
    /// <summary>
    /// The unique identifier of the vehicle.
    /// </summary>
    public VehicleId Id { get; set; } = VehicleId.Default;

    /// <summary>
    /// The name of this vehicle. The common name, such as "Sand Crawler" or
    /// "Speeder bike".
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The model or official name of this vehicle. Such as "All-Terrain Attack
    /// Transport".
    /// </summary>
    public string Model { get; set; } = default!;

    /// <summary>
    /// The class of this vehicle, such as "Wheeled" or "Repulsorcraft".
    /// </summary>
    public string VehicleClass { get; set; } = default!;

    /// <summary>
    /// A collection of manufacturers of the vehicle.
    /// </summary>
    public ICollection<string> Manufacturer { get; set; } = default!;

    /// <summary>
    /// The length of this vehicle in meters.
    /// </summary>
    public string Length { get; set; } = default!;

    /// <summary>
    /// The cost of this vehicle new, in Galactic Credits.
    /// </summary>
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
    public string MaxAtmospheringSpeed { get; set; } = default!;

    /// <summary>
    /// The maximum number of kilograms that this vehicle can transport.
    /// </summary>
    public string CargoCapacity { get; set; } = default!;

    /// <summary>
    /// The maximum length of time that this vehicle can provide consumables for
    /// its entire crew without having to resupply.
    /// </summary>
    public string Consumables { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = default!;
}
