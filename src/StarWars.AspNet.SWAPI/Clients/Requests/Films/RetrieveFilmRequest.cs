using SWApiClient.Models;

namespace SWApiClient.Requests.Films;

/// <summary>
/// Models encapsulating data to make a request to retrieve a <see cref="Film"/>.
/// </summary>
public class RetrieveFilmRequest
{
    /// <summary>
    /// The StarWars API identifier for the film.
    /// </summary>
    public string FilmId { get; set; } = default!;
}
