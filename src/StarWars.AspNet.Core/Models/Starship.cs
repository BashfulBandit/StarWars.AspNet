using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

public class Starship
{
    public StarshipId Id { get; set; } = StarshipId.Default;

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
