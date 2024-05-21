using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using SWApiClient.Requests.Films;
using SWApiClient.Responses.Films;

namespace StarWars.AspNet.SWAPI.Mappings.Episodes;

internal static class ListFilmsMappers
{
    public static ListFilmsRequest ToRequest(this EpisodesSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IPage<Episode> ToModel(this ListFilmsResponse response)
        => new Page<SWApiClient.Models.Film>(response.Results.ToList(), response.ParseCurrentPageNumber(), response.Results.Count(), response.Count)
            .MapTo(p => p.ToModel());

    public static IQueryable<SWApiClient.Models.Film> Filter(this IQueryable<SWApiClient.Models.Film> query,
        EpisodesSearchFilter _)
    {
        // Currently doesn't do anything, but it is here to add later.
        return query;
    }

    public static IQueryable<SWApiClient.Models.Film> Sort(this IQueryable<SWApiClient.Models.Film> query,
        EpisodesSearchFilter _)
    {
        // Currently doesn't do anything, but it is here to add later.
        return query;
    }
}
