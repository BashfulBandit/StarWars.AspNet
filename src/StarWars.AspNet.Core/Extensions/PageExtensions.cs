using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Extensions;

/// <summary>
/// Extension methods for a <see cref="Page{T}"/>.
/// </summary>
public static class PageExtensions
{
    /// <summary>
    /// Create a <see cref="Page{T}"/> from an <see cref="IQueryable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the collection.</typeparam>
    /// <param name="source">The collection of <typeparamref name="T"/>.</param>
    /// <param name="page">The page to return.</param>
    /// <param name="pageSize">The size of pages.</param>
    /// <returns>The returned page containing it's metadata about the pages.</returns>
    public static IPage<T> Paginate<T>(this IQueryable<T> source,
        int page = Page.DefaultPageNumber,
        int pageSize = Page.DefaultPageSize)
        => new Page<T>(source, page, pageSize);
}
