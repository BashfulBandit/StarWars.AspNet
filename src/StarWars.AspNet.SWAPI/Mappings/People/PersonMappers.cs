using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.People;

internal static class PersonMappers
{
    public static Person ToModel(this Clients.Models.Person person)
        => new()
        {
            Id = PersonId.From(person.Url.ParseId()),
            Name = person.Name,
            Height = person.Height,
            Mass = person.Mass,
            HairColor = person.HairColor,
            SkinColor = person.SkinColor,
            EyeColor = person.EyeColor,
            BirthYear = person.BirthYear,
            Gender = person.Gender,
            // TODO: What to do here?
            // Home = person.Homeworld,
            CreatedAt = person.Created,
            UpdatedAt = person.Edited
        };
}
