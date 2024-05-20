using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Characters;
using StarWars.AspNet.Api.Responses.Characters;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Queries.Characters;

namespace StarWars.AspNet.Api.Mappings.Characters;

internal static class ListCharactersMappers
{
    public static ListCharacters ToQuery(this ListCharactersRequest request)
        => ListCharacters.ToQuery(request.ToFilter());

    public static CharactersSearchFilter ToFilter(this ListCharactersRequest request)
        => new()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            Name = request.Name
        };

    public static ListCharactersResponse ToResponse(this ListCharactersResult result)
        => new()
        {
            Characters = result.Page!.Items.Select(s => s.ToDto()),
            Pagination = result.Page.ToDto()
        };
}
