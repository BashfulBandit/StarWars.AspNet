using StarWars.AspNet.Api.Models;

namespace StarWars.AspNet.Api.Responses;

/// <summary>
/// Abstract class to define a base page reponse from an API.
/// </summary>
internal abstract class PageResponse
{
    /// <summary>
    /// The pagination meta data.
    /// </summary>
    public PaginationDto Pagination { get; init; } = default!;
}
