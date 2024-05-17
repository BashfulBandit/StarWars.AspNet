using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.SWAPI.Clients.Requests.Planets;
using StarWars.AspNet.SWAPI.Clients.Responses.Planets;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Planets;

internal static class ListPlanetsMappers
{
    private const string PageQueryParam = "page";

    public static ListPlanetsRequest ToRequest(this PlanetsSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IPage<Planet> ToModel(this ListPlanetsResponse response)
        => new Page<Clients.Models.Planet>(response.Results.ToList(), response.PageNumber(), response.Results.Count(), response.Count)
            .MapTo(p => p.ToModel());

    public static int PageNumber(this ListPlanetsResponse response)
    {
        if (response.Next is not null
            && response.Next.TryParseQueryParameter(PageQueryParam, out var nextPageStr)
            && int.TryParse(nextPageStr, out var nextPage))
        {
            // The next page number is not the current page number, so we subtract one.
            return nextPage - 1;
        }
        else if (response.Previous is not null
            && response.Previous.TryParseQueryParameter(PageQueryParam, out var prevPageStr)
            && int.TryParse(prevPageStr, out var prevPage))
        {
            // The previous page number is not the current page number, so we add one.
            return prevPage + 1;
        }
        return IPage.DefaultPageNumber;
    }
}
