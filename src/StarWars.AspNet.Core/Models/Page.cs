namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Simple implementation of an <see cref="IPage"/> to provide the base
/// calculations of the page metadata.
/// </summary>
public class Page
    : IPage
{
    public const int MinPage = IPage.MinPage;
    public const int DefaultPageNumber = IPage.DefaultPageNumber;
    public const int DefaultPageSize = IPage.DefaultPageSize;
    public const int DefaultPageCount = IPage.DefaultPageCount;
    public const int DefaultTotalCount = IPage.DefaultTotalCount;

    public Page(int totalCount = DefaultTotalCount,
        int pageNumber = DefaultPageNumber,
        int pageSize = DefaultPageSize)
    {
        this.PageNumber = Math.Max(MinPage, pageNumber);
        this.PageSize = Math.Min(int.MaxValue, Math.Max(1, pageSize));
        this.TotalCount = Math.Max(0, totalCount);
        this.PageCount = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);
    }

    /// <summary>
    /// The number of the page.
    /// </summary>
    public int PageNumber { get; init; } = DefaultPageNumber;

    /// <summary>
    /// The size of the page.
    /// </summary>
    public int PageSize { get; init; } = DefaultPageSize;

    /// <summary>
    /// Total number of pages possible.
    /// </summary>
    public int PageCount { get; init; } = DefaultPageCount;

    /// <summary>
    /// Total number of entries in the collection.
    /// </summary>
    public int TotalCount { get; init; } = DefaultTotalCount;
}

/// <summary>
/// Simple implementation of an <see cref="IPage{T}"/> to provide the base
/// functionality of mapping from one resource to another.
/// </summary>
/// <typeparam name="T">The type of resources returned.</typeparam>
public class Page<T>
    : Page,
    IPage<T>
{
    public static readonly IList<T> DefaultItems = IPage<T>.DefaultItems;

    public Page(IList<T> items,
        int pageNumber,
        int pageSize,
        int totalCount)
        : base(totalCount, pageNumber, pageSize)
    {
        this.Items = items;
    }

    public Page(IQueryable<T> source,
        int pageNumber = DefaultPageNumber,
        int pageSize = DefaultPageSize)
        : base(source.Count(), pageNumber, pageSize)
    {
        this.Items = source.Skip((this.PageNumber - 1) * this.PageSize)
            .Take(this.PageSize)
            .ToList();
    }

    /// <summary>
    /// Private ctor used by <see cref="MapTo{TTarget}" />
    /// </summary>
    private Page(IList<T> items)
        => this.Items = items;

    public Page()
    { }

    /// <inheritdoc />
    public IList<T> Items { get; init; } = DefaultItems;

    /// <inheritdoc />
    public IPage<TTarget> MapTo<TTarget>(Func<T, TTarget> mapFunc)
    {
        var mapped = new Page<TTarget>(this.Items.Select(mapFunc).ToList())
        {
            PageCount = this.PageCount,
            PageNumber = this.PageNumber,
            PageSize = this.PageSize,
            TotalCount = this.TotalCount
        };
        return mapped;
    }
}
