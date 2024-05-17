using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Clients.Requests.Films;
using StarWars.AspNet.SWAPI.Clients.Responses.Films;

namespace StarWars.AspNet.SWAPI.Mappings.Episodes;

internal static class RetrieveFilmMappers
{
    public static RetrieveFilmRequest ToRequest(this EpisodeId id)
        => new()
        {
            FilmId = id.Value
        };

    public static Episode ToModel(this RetrieveFilmResponse response)
        => (response as Clients.Models.Film).ToModel();
}
