using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Vehicles;

internal static class VehicleMappers
{
    public static Vehicle ToModel(this SWApiClient.Models.Vehicle vehicle)
        => new()
        {
            Id = VehicleId.From(vehicle.Url.ParseId()),
            Name = vehicle.Name,
            Model = vehicle.Model,
            VehicleClass = vehicle.VehicleClass,
            Manufacturer = vehicle.Manufacturer.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Length = vehicle.Length,
            CostInCredits = vehicle.CostInCredits,
            Crew = vehicle.Crew,
            Passengers = vehicle.Passengers,
            MaxAtmospheringSpeed = vehicle.MaxAtmospheringSpeed,
            CargoCapacity = vehicle.CargoCapacity,
            Consumables = vehicle.Consumables,
            CreatedAt = vehicle.Created,
            UpdatedAt = vehicle.Edited
        };
}
