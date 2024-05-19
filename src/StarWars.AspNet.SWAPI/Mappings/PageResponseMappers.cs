using SWApiClient.Responses;
using StarWars.AspNet.SWAPI.Extensions;

namespace StarWars.AspNet.SWAPI.Mappings;

/// <summary>
/// Extension methods for an <see cref="PageResponse{T}"/>.
/// </summary>
internal static class PageResponseMappers
{
    /// <summary>
    /// Extension method to parse the page number of the <see cref="PageResponse{T}"/>.
    /// </summary>
    /// <param name="response">The <see cref="PageResponse{T}"/>.</param>
    /// <returns>The page number of the <see cref="PageResponse{T}"/>.</returns>
    public static int ParseCurrentPageNumber<T>(this PageResponse<T> response)
    {
        if (response.Next.TryParsePageNumber(out var nextPageNumber))
        {
            // The next page number is not the current page number, so we subtract one.
            return nextPageNumber - 1;
        }
        else if (response.Previous.TryParsePageNumber(out var prevPageNumber))
        {
            // The previous page number is not the current page number, so we add one.
            return prevPageNumber + 1;
        }
        // If both `Next` and `Previous` are null or empty or not an `int`. Then
        // it is safe to assume it is the first page. So simply return 1.
        return 1;
    }
}
