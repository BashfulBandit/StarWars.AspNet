using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses;

internal abstract class PageResponse
{
    public PaginationDto Pagination { get; init; } = default!;
}
