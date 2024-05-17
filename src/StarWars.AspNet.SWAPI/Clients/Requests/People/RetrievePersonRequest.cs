using StarWars.AspNet.SWAPI.Clients.Models;

namespace StarWars.AspNet.SWAPI.Clients.Requests.People;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Person"/>.
/// </summary>
internal class RetrievePersonRequest
{
    /// <summary>
    /// The StarWars API identifier for the person.
    /// </summary>
    public string PersonId { get; set; } = default!;
}
