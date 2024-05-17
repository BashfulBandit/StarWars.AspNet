using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Episodes;

internal static class EpisodeMappers
{
    public static Core.Models.Episode ToModel(this Clients.Models.Film film)
        => new()
        {
            Id = EpisodeId.From(film.Url.ParseId()),
            Title = film.Title,
            ReleaseOrder = film.EpisodeId,
            OpeningCrawl = film.OpeningCrawl,
            Director = film.Director,
            Producer = film.Producer,
            ReleaseDate = film.ReleaseDate,
            CreatedAt = film.Created,
            UpdatedAt = film.Edited
        };
}
