using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.Films;

/// <summary>
/// Models encapsulating data to make a request to retrieve a <see cref="Film"/>.
/// </summary>
internal class RetrieveFilmRequest
{
    /// <summary>
    /// The StarWars API identifier for the film.
    /// </summary>
    public string FilmId { get; set; } = default!;
}
