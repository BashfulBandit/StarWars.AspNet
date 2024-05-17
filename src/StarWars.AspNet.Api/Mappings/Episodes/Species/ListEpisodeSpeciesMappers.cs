using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Episodes;
using StarWars.AspNet.Api.Responses.Episodes.Species;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Queries.Episodes.Species;

namespace StarWars.AspNet.Api.Mappings.Episodes.Species;

internal static class ListEpisodeSpeciesMappers
{
    public static ListEpisodeSpecies ToQuery(this ListEpisodeSpeciesRequest request)
        => ListEpisodeSpecies.ToQuery(request.ToFilter());

    public static SpeciesSearchFilter ToFilter(this ListEpisodeSpeciesRequest request)
        => new()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            EpisodeId = EpisodeId.From(request.EpisodeId)
        };

    public static ListEpisodeSpeciesResponse ToResponse(this ListEpisodeSpeciesResult result)
        => new()
        {
            Species = result.Page!.Items.Select(s => s.ToDto()),
            Pagination = result.Page.ToDto()
        };
}
