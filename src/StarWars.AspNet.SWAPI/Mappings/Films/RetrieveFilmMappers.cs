using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Clients.Requests.Films;
using StarWars.AspNet.SWAPI.Clients.Responses.Films;

namespace StarWars.AspNet.SWAPI.Mappings.Films;

internal static class RetrieveFilmMappers
{
    public static RetrieveFilmRequest ToRequest(this FilmId id)
        => new()
        {
            FilmId = id.Value
        };

    public static Film ToModel(this RetrieveFilmResponse response)
        => (response as Clients.Models.Film).ToModel();
}
