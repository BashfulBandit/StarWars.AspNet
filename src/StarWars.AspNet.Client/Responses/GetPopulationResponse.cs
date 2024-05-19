namespace StarWars.AspNet.Client.Responses;

/// <summary>
/// A response representing a successful request to the Star Wars API to
/// get the Star Wars universe's known population.
/// </summary>
public class GetPopulationResponse
{
    /// <summary>
    /// The total known population in the Star Wars universe.
    /// </summary>
    public ulong Population { get; set; } = default;
}
