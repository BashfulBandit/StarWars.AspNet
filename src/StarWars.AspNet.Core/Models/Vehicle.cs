using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

public class Vehicle
{
    public VehicleId Id { get; set; } = VehicleId.Default;

    public string Name { get; set; } = default!;

    public string Model { get; set; } = default!;

    public string VehicleClass { get; set; } = default!;

    public string Manufacturer { get; set; } = default!;

    public string Length { get; set; } = default!;

    public string CostInCredits { get; set; } = default!;

    public string Crew { get; set; } = default!;

    public string Passengers { get; set; } = default!;

    public string MaxAtmospheringSpeed { get; set; } = default!;

    public string CargoCapacity { get; set; } = default!;

    public string Consumables { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default;

    public DateTime UpdatedAt { get; set; } = default;
}
