namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Interface to define the base of a page.
/// </summary>
public interface IPage
{
    public const int MinPage = 1;
    public const int DefaultPageNumber = MinPage;
    public const int DefaultPageSize = 25;
    public const int DefaultPageCount = 0;
    public const int DefaultTotalCount = 0;

    /// <summary>
    /// The number of the page.
    /// </summary>
    int PageNumber { get => DefaultPageNumber; }

    /// <summary>
    /// The size of the page.
    /// </summary>
    int PageSize { get => DefaultPageSize; }

    /// <summary>
    /// Total number of pages possible.
    /// </summary>
    int PageCount { get => DefaultPageCount; }

    /// <summary>
    /// Total number of entries in the collection.
    /// </summary>
    int TotalCount { get => DefaultTotalCount; }

    /// <summary>
    /// Whether or not there is a page before this one.
    /// </summary>
    bool HasPrevious { get => this.PageNumber > MinPage; }

    /// <summary>
    /// Whether or not there is another page after this one.
    /// </summary>
    bool HasNext { get => this.PageNumber < this.PageCount; }
}

/// <summary>
/// Interface to define the base of a page of resources.
/// </summary>
/// <typeparam name="T">The type of resources returned.</typeparam>
public interface IPage<T>
    : IPage
{
    public static readonly IList<T> DefaultItems = Array.Empty<T>();

    /// <summary>
    /// List of items being paginated
    /// </summary>
    IList<T> Items { get => DefaultItems; }

    /// <summary>
    /// Used to map items of type T to the target type TTarget.
    /// </summary>
    /// <param name="mapFunc">The mapping function.</param>
    /// <typeparam name="TTarget">The target type.</typeparam>
    /// <returns>The paginated list mapped to TTarget type.</returns>
    IPage<TTarget> MapTo<TTarget>(Func<T, TTarget> mapFunc);
}
