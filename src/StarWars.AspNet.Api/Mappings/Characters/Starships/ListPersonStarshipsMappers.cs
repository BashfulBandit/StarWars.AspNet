using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Characters.Starships;
using StarWars.AspNet.Api.Responses.Characters.Starships;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Queries.Characters.Starships;

namespace StarWars.AspNet.Api.Mappings.Characters.Starships;

internal static class ListCharacterStarshipsMappers
{
    public static ListCharacterStarships ToQuery(this ListCharacterStarshipsRequest request)
        => ListCharacterStarships.ToQuery(request.ToFilter());

    public static StarshipsSearchFilter ToFilter(this ListCharacterStarshipsRequest request)
        => new()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            PersonId = CharacterId.From(request.CharacterId)
        };

    public static ListCharacterStarshipsResponse ToResponse(this ListCharacterStarshipsResult result)
        => new()
        {
            Starships = result.Page!.Items.Select(s => s.ToDto()),
            Pagination = result.Page.ToDto()
        };
}
