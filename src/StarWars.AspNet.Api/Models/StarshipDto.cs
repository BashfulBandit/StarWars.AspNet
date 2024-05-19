using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Api.Models;

/// <summary>
/// DTO of a starship in the Star Wars universe.
/// </summary>
internal class StarshipDto
{
    /// <summary>
    /// The unique identifier of the starship.
    /// </summary>
    public string Id { get; set; } = default!;

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
    /// The class of this starship, such as "Starfighter" or "Deep Space Mobile Battlestation"
    /// </summary>
    public string StarshipClass { get; set; } = default!;

    /// <summary>
    /// A collection of manufacturers of the starship.
    /// </summary>
    public ICollection<string> Manufacturer { get; set; } = default!;

    /// <summary>
    /// The cost of this starship new, in galactic credits.
    /// </summary>
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
    public string MaxAtmospheringSpeed { get; set; } = default!;

    /// <summary>
    /// The class of this starships hyperdrive.
    /// </summary>
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
    public string CargoCapacity { get; set; } = default!;

    /// <summary>
    /// The maximum length of time that this starship can provide consumables
    /// for its entire crew without having to resupply.
    /// </summary>
    public string Consumables { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = default;

    /// <summary>
    /// The date and time this resource was last updated.
    /// </summary>
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
            Manufacturer = model.Manufacturers,
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
