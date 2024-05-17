using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Films;

internal static class FilmMappers
{
    public static Core.Models.Film ToModel(this Clients.Models.Film film)
        => new()
        {
            Id = FilmId.From(film.Url.ParseId()),
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
