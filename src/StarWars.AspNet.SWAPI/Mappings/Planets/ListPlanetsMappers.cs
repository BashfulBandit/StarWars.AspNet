using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.SWAPI.Clients.Requests.Planets;

namespace StarWars.AspNet.SWAPI.Mappings.Planets;

internal static class ListPlanetsMappers
{
    public static ListPlanetsRequest ToRequest(this PlanetsSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IQueryable<Clients.Models.Planet> Filter(this IQueryable<Clients.Models.Planet> query,
        PlanetsSearchFilter _)
    {
        return query;
    }

    public static IQueryable<Clients.Models.Planet> Sort(this IQueryable<Clients.Models.Planet> query,
        PlanetsSearchFilter _)
    {
        return query;
    }
}
