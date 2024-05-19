using StarWars.AspNet.Core.Models.Filters;
using SWApiClient.Models;
using SWApiClient.Requests.Planets;

namespace StarWars.AspNet.SWAPI.Mappings.Planets;

internal static class ListPlanetsMappers
{
    public static ListPlanetsRequest ToRequest(this PlanetsSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IQueryable<Planet> Filter(this IQueryable<Planet> query,
        PlanetsSearchFilter _)
    {
        return query;
    }

    public static IQueryable<Planet> Sort(this IQueryable<Planet> query,
        PlanetsSearchFilter _)
    {
        return query;
    }
}
