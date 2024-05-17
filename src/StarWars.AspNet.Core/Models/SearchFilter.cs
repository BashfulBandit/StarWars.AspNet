namespace StarWars.AspNet.Core.Models;

/// <inheritdoc/>
public class SearchFilter
    : ISearchFilter
{
    public const int DefaultPage = ISearchFilter.DefaultPage;
    public const int DefaultPageSize = ISearchFilter.DefaultPageSize;

    public SearchFilter(int page = DefaultPage,
        int pageSize = DefaultPageSize)
    {
        this.Page = page;
        this.PageSize = pageSize;
    }

    /// <inheritdoc/>
    public int Page { get; init; }

    /// <inheritdoc/>
    public int PageSize { get; init; }
}

/// <inheritdoc/>
public class SearchFilter<TSortProperty>
    : SearchFilter,
    ISearchFilter<TSortProperty>
    where TSortProperty : struct, Enum
{
    public const SortOrder DefaultOrder = ISearchFilter<TSortProperty>.DefaultOrder;
    public static readonly TSortProperty DefaultSort = default;

    public SearchFilter(int page = DefaultPage,
        int pageSize = DefaultPageSize,
        SortOrder order = DefaultOrder,
        TSortProperty sort = default)
        : base(page, pageSize)
    {
        this.Order = order;
        this.Sort = sort;
    }

    /// <inheritdoc/>
    public TSortProperty Sort { get; init; }

    /// <inheritdoc/>
    public SortOrder Order { get; init; }
}
