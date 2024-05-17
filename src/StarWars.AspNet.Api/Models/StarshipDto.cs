using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Api.Models;

internal class StarshipDto
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string Model { get; set; } = default!;

    public string StarshipClass { get; set; } = default!;

    public string Manufacturer { get; set; } = default!;

    public string CostInCredits { get; set; } = default!;

    public string Length { get; set; } = default!;

    public string Crew { get; set; } = default!;

    public string Passengers { get; set; } = default!;

    public string MaxAtmospheringSpeed { get; set; } = default!;

    public string HyperdriveRating { get; set; } = default!;

    public string MGLT { get; set; } = default!;

    public string CargoCapacity { get; set; } = default!;

    public string Consumables { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default;

    public DateTime UpdatedAt { get; set; } = default;
}

internal static class StarshipExtensions
{
    public static StarshipDto ToDto(this Starship model)
        => new()
        {
            Id = model.Id.Value,
            Name = model.Name,
            Model = model.Model,
            StarshipClass = model.StarshipClass,
            Manufacturer = model.Manufacturer,
            CostInCredits = model.CostInCredits,
            Length = model.Length,
            Crew = model.Crew,
            Passengers = model.Passengers,
            MaxAtmospheringSpeed = model.MaxAtmospheringSpeed,
            HyperdriveRating = model.HyperdriveRating,
            MGLT = model.MGLT,
            CargoCapacity = model.CargoCapacity,
            Consumables = model.Consumables,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
}
