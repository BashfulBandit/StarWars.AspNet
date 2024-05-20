using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;
using SWApiClient.Models;

namespace StarWars.AspNet.SWAPI.Mappings.Characters;

internal static class CharacterMappers
{
    public static Character ToModel(this Person person)
        => new()
        {
            Id = CharacterId.From(person.Url.ParseId()),
            Name = person.Name,
            Height = person.Height,
            Mass = person.Mass,
            HairColor = person.HairColor,
            SkinColor = person.SkinColor,
            EyeColor = person.EyeColor,
            BirthYear = person.BirthYear,
            Gender = person.Gender,
            CreatedAt = person.Created,
            UpdatedAt = person.Edited
        };
}
