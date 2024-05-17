namespace StarWars.AspNet.SWAPI.Clients.Requests.Species;

/// <summary>
/// Model encapsulating data to make a request to retrieve a <see cref="Models.Species"/>.
/// </summary>
internal class RetrieveSpeciesRequest
{
    /// <summary>
    /// The StarWars API identifier for the species.
    /// </summary>
    public string SpeciesId { get; set; } = default!;
}
