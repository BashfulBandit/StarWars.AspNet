namespace SWApiClient.Requests.Starships;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Models.Starship"/>.
/// </summary>
public class RetrieveStarshipRequest
{
    /// <summary>
    /// The StarWars API identifier for the starhip.
    /// </summary>
    public string StarshipId { get; set; } = default!;
}
