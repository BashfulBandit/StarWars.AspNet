using StarWars.AspNet.Core.Queries.Planets;

namespace StarWars.AspNet.Api.Responses.Planets;

internal class GetPopulationResponse
{
    public ulong Population { get; set; } = default;
}

internal static class GetPopulationResponseExtensions
{
    public static GetPopulationResponse ToResponse(this CalculatePopulationResult result)
        => new()
        {
            Population = result.Population
        };
}
