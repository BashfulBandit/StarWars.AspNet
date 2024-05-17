using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Clients.Requests.Starships;
using StarWars.AspNet.SWAPI.Clients.Responses.Starships;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Starships;

internal static class ListStarshipsMappers
{
    public static ListStarshipsRequest ToRequest(this StarshipsSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IPage<Core.Models.Starship> ToModel(this ListStarshipsResponse response)
        => new Page<Clients.Models.Starship>(response.Results.ToList(), response.PageNumber(), response.Results.Count(), response.Count)
            .MapTo(s => s.ToModel());

    public static IQueryable<Clients.Models.Starship> Filter(this IQueryable<Clients.Models.Starship> query,
        StarshipsSearchFilter filter)
    {
        if (filter.PersonId is not null)
        {
            query = query.Where(s => s.Pilots.Select(p => PersonId.From(p.ParseId())).ToList().Contains(filter.PersonId.Value));
        }
        return query;
    }

    public static IQueryable<Clients.Models.Starship> Sort(this IQueryable<Clients.Models.Starship> query,
        StarshipsSearchFilter _)
    {
        // Currently doesn't do anything, but it is here to add later.
        return query;
    }
}
