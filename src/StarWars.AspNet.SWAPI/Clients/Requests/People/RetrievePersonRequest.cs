using SWApiClient.Models;

namespace SWApiClient.Requests.People;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Person"/>.
/// </summary>
public class RetrievePersonRequest
{
    /// <summary>
    /// The StarWars API identifier for the person.
    /// </summary>
    public string PersonId { get; set; } = default!;
}
