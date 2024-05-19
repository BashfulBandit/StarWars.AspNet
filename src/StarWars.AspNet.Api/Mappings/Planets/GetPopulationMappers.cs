using StarWars.AspNet.Api.Responses.Planets;
using StarWars.AspNet.Core.Commands.Planets;

namespace StarWars.AspNet.Api.Mappings.Planets;

internal static class GetPopulationMappers
{
    public static GetPopulationResponse ToResponse(this CalculatePopulationResult result)
        => new()
        {
            Population = result.Population
        };
}
