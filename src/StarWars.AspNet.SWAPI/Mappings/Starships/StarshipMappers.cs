using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Starships;

internal static class StarshipMappers
{
    public static Starship ToModel(this Clients.Models.Starship starship)
        => new()
        {
            Id = StarshipId.From(starship.Url.ParseId()),
            Name = starship.Name,
            Model = starship.Model,
            StarshipClass = starship.StarshipClass,
            Manufacturer = starship.Manufacturer,
            CostInCredits = starship.CostInCredits,
            Length = starship.Length,
            Crew = starship.Crew,
            Passengers = starship.Passengers,
            MaxAtmospheringSpeed  = starship.MaxAtmospheringSpeed,
            MGLT = starship.MGLT,
            CargoCapacity = starship.CargoCapacity,
            Consumables = starship.Consumables,
            CreatedAt = starship.Created,
            UpdatedAt = starship.Edited
        };
}
