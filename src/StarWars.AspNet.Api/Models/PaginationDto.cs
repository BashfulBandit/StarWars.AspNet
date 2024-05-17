using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Api.Models;

/// <summary>
/// The pagination metadata.
/// </summary>
internal class PaginationDto
{
    public const int MinPageNumber = 1;
    public const int DefaultPageNumber = MinPageNumber;
    public const int DefaultPageSize = 25;
    public const int DefaultPageCount = 0;
    public const int DefaultTotalCount = 0;

    /// <summary>
    /// The number of the page.
    /// </summary>
    public int PageNumber { get; set; } = DefaultPageNumber;

    /// <summary>
    /// The size of the page.
    /// </summary>
    public int PageSize { get; set; } = DefaultPageSize;

    /// <summary>
    /// Total number of pages possible.
    /// </summary>
    public int PageCount { get; set; } = DefaultPageCount;

    /// <summary>
    /// Total number of entries in the collection.
    /// </summary>
    public int TotalCount { get; set; } = DefaultTotalCount;

    /// <summary>
    /// Whether or not there is a page before this one.
    /// </summary>
    public bool HasPrevious => this.PageNumber > MinPageNumber;

    /// <summary>
    /// Whether or not there is another page after this one.
    /// </summary>
    public bool HasNext => this.PageNumber < this.PageCount;
}

internal static class PaginationDtoExtensions
{
    public static PaginationDto ToDto(this IPage page)
        => new()
        {
            PageNumber = page.PageNumber,
            PageSize = page.PageSize,
            PageCount = page.PageCount,
            TotalCount = page.TotalCount
        };
}
