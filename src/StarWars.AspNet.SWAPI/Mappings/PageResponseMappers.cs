using StarWars.AspNet.Core.Models;
using StarWars.AspNet.SWAPI.Clients.Responses;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings;

internal static class PageResponseMappers
{
    private const string PageQueryParam = "page";

    public static int PageNumber<T>(this PageResponse<T> response)
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
