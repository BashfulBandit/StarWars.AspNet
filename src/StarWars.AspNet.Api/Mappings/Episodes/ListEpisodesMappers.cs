using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Episodes;
using StarWars.AspNet.Api.Responses.Episodes;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Queries.Episodes;

namespace StarWars.AspNet.Api.Mappings.Episodes;

internal static class ListEpisodesMappers
{
    public static ListEpisodes ToQuery(this ListEpisodesRequest request)
        => ListEpisodes.ToQuery(request.ToFilter());

    public static EpisodesSearchFilter ToFilter(this ListEpisodesRequest request)
        => new()
        {
            Page = request.Page,
            PageSize = request.PageSize
        };

    public static ListEpisodesResponse ToResponse(this ListEpisodesResult result)
        => new()
        {
            Episodes = result.Page!.Items.Select(s => s.ToDto()),
            Pagination = result.Page.ToDto()
        };
}
