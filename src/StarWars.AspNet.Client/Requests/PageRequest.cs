namespace StarWars.AspNet.Client.Requests;

/// <summary>
/// Abstract class for a client page request.
/// </summary>
public abstract class PageRequest
{
    public const string PageQueryKey = "page";
    public const string PageSizeQueryKey = "pageSize";

    public const int DefaultPage = 1;
    public const int DefaultPageSize = 25;

    /// <summary>
    /// The page to retrieve.
    /// </summary>
    public int Page { get; set; } = DefaultPage;

    /// <summary>
    /// The size of the pages.
    /// </summary>
    public int PageSize { get; set; } = DefaultPageSize;
}

