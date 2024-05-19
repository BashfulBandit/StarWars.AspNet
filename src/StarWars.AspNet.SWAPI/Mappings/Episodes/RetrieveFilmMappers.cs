using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using SWApiClient.Models;
using SWApiClient.Requests.Films;
using SWApiClient.Responses.Films;

namespace StarWars.AspNet.SWAPI.Mappings.Episodes;

internal static class RetrieveFilmMappers
{
    public static RetrieveFilmRequest ToRequest(this EpisodeId id)
        => new()
        {
            FilmId = id.Value
        };

    public static Episode ToModel(this RetrieveFilmResponse response)
        => (response as Film).ToModel();
}
