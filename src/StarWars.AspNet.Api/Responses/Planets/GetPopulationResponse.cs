using StarWars.AspNet.Core.Commands.Planets;

namespace StarWars.AspNet.Api.Responses.Planets;

/// <summary>
/// Response from a successful request to retrieve the total known population of
/// the Star Wars universe.
/// </summary>
internal class GetPopulationResponse
{
    /// <summary>
    /// The total known population of the Star Wars universe.
    /// </summary>
    public ulong Population { get; set; } = default;
}
