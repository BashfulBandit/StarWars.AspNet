namespace StarWars.AspNet.Client.Models;

/// <summary>
/// The page metadata
/// </summary>
public class Pagination
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    public const int DefaultPageCount = 0;
    public const int DefaultTotalCount = 0;
    public const bool DefaultHasPrevious = false;
    public const bool DefaultHasNext = false;

    /// <summary>
    /// The number of the page retrieved.
    /// </summary>
    public int PageNumber { get; set; } = DefaultPageNumber;

    /// <summary>
    /// The size of pages.
    /// </summary>
    public int PageSize { get; set; } = DefaultPageSize;

    /// <summary>
    /// The number of items on the page.
    /// </summary>
    public int PageCount { get; set; } = DefaultPageCount;

    /// <summary>
    /// The total number of items in the service.
    /// </summary>
    public int TotalCount { get; set; } = DefaultTotalCount;

    /// <summary>
    /// Indicator of whether there is a page before this page.
    /// </summary>
    public bool HasPrevious { get; set; } = DefaultHasPrevious;

    /// <summary>
    /// Indicator of whether there is a page after this page.
    /// </summary>
    public bool HasNext { get; set; } = DefaultHasNext;
}
