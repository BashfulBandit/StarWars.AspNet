namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Interface to define the base of a search filter in Core.
/// </summary>
public interface ISearchFilter
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 25;

    /// <summary>
    /// The page number of the results to return.
    /// </summary>
    int Page { get => DefaultPage; }

    /// <summary>
    /// The page size of the results to return.
    /// </summary>
    int PageSize { get => DefaultPageSize; }
}

/// <summary>
/// An enumeration of supported sort orders.
/// </summary>
public enum SortOrder
{
    /// <summary>
    /// Sort the results in ascending order.
    /// </summary>
    Ascending,

    /// <summary>
    /// Sort the results in descending order.
    /// </summary>
    Descending
}

/// <summary>
/// Interface to define a search filter with a sort property in Core.
/// </summary>
/// <typeparam name="TSortProperty"></typeparam>
public interface ISearchFilter<TSortProperty>
    : ISearchFilter
    where TSortProperty : struct, Enum
{
    public const SortOrder DefaultOrder = SortOrder.Ascending;
    public static readonly TSortProperty DefaultSort = default;

    /// <summary>
    /// The direction by which the results should be sorted.
    /// </summary>
    SortOrder Order { get => DefaultOrder; }

    /// <summary>
    /// Sort the results by 
    /// </summary>
    TSortProperty Sort { get => DefaultSort; }
}
