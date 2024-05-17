using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.People.Starships;
using StarWars.AspNet.Api.Responses.Episodes.Species;
using StarWars.AspNet.Api.Responses.People.Starships;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Queries.Episodes.Species;
using StarWars.AspNet.Core.Queries.People.Starships;

namespace StarWars.AspNet.Api.Mappings.People.Starships;

internal static class ListPersonStarshipsMappers
{
    public static ListPersonStarships ToQuery(this ListPersonStarshipsRequest request)
        => ListPersonStarships.ToQuery(request.ToFilter());

    public static StarshipsSearchFilter ToFilter(this ListPersonStarshipsRequest request)
        => new()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            PersonId = PersonId.From(request.PersonId)
        };

    public static ListPersonStarshipsResponse ToResponse(this ListPersonStarshipsResult result)
        => new()
        {
            Starships = result.Page!.Items.Select(s => s.ToDto()),
            Pagination = result.Page.ToDto()
        };
}
