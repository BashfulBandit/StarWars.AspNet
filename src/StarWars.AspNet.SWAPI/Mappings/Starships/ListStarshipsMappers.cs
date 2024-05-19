using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Extensions;
using SWApiClient.Requests.Starships;
using SWApiClient.Responses.Starships;

namespace StarWars.AspNet.SWAPI.Mappings.Starships;

internal static class ListStarshipsMappers
{
    public static ListStarshipsRequest ToRequest(this StarshipsSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IPage<Core.Models.Starship> ToModel(this ListStarshipsResponse response)
        => new Page<SWApiClient.Models.Starship>(response.Results.ToList(), response.ParseCurrentPageNumber(), response.Results.Count(), response.Count)
            .MapTo(s => s.ToModel());

    public static IQueryable<SWApiClient.Models.Starship> Filter(this IQueryable<SWApiClient.Models.Starship> query,
        StarshipsSearchFilter filter)
    {
        if (filter.PersonId is not null)
        {
            query = query.Where(s => s.Pilots.Select(p => CharacterId.From(p.ParseId())).ToList().Contains(filter.PersonId.Value));
        }
        return query;
    }

    public static IQueryable<SWApiClient.Models.Starship> Sort(this IQueryable<SWApiClient.Models.Starship> query,
        StarshipsSearchFilter _)
    {
        // Currently doesn't do anything, but it is here to add later.
        return query;
    }
}
