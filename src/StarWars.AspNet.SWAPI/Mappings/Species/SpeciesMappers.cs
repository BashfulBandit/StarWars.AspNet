using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Species;

internal static class SpeciesMappers
{
    public static Core.Models.Species ToModel(this Clients.Models.Species species)
        => new()
        {
            Id = SpeciesId.From(species.Url.ParseId()),
            Name = species.Name,
            Classification = species.Classification,
            Designation = species.Designation,
            AverageHeight = species.AverageHeight,
            AverageLifespace = species.AverageLifespace,
            EyeColors = species.EyeColors.Split(','),
            HairColors = species.HairColors.Split(','),
            SkinColors = species.SkinColors.Split(','),
            Language = species.Language,
            // TODO: What to do here?
            // Home = species.Homeworld,
            CreatedAt = species.Created,
            UpdatedAt = species.Edited,
        };
}
