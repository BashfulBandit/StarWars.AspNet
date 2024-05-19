using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using SWApiClient.Requests.Species;
using SWApiClient.Responses.Species;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings.Species;

internal static class ListSpeciesMappers
{
    public static ListSpeciesRequest ToRequest(this SpeciesSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IPage<Core.Models.Species> ToModel(this ListSpeciesResponse response)
        => new Page<SWApiClient.Models.Species>(response.Results.ToList(), response.ParseCurrentPageNumber(), response.Results.Count(), response.Count)
            .MapTo(p => p.ToModel());

    public static IQueryable<SWApiClient.Models.Species> Filter(this IQueryable<SWApiClient.Models.Species> query,
        SpeciesSearchFilter filter)
    {
        if (filter.EpisodeId is not null)
        {
            query = query.Where(s => s.Films.Select(f => EpisodeId.From(f.ParseId())).ToList().Contains(filter.EpisodeId.Value));
        }
        return query;
    }

    public static IQueryable<SWApiClient.Models.Species> Sort(this IQueryable<SWApiClient.Models.Species> query,
        SpeciesSearchFilter _)
    {
        // Currently doesn't do anything, but it is here to add later.
        return query;
    }
}
