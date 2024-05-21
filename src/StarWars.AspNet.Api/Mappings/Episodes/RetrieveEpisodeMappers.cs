using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Episodes;
using StarWars.AspNet.Api.Responses.Episodes;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Queries.Episodes;

namespace StarWars.AspNet.Api.Mappings.Episodes;

internal static class RetrieveEpisodeMappers
{
    public static FetchEpisodeById ToQuery(this RetrieveEpisodeRequest request)
        => FetchEpisodeById.ToQuery(EpisodeId.From(request.EpisodeId));

    public static RetrieveEpisodeResponse ToResponse(this FetchEpisodeByIdResult result)
        => new()
        {
            Episode = result.Episode!.ToDto()
        };
}
