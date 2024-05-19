using System.Diagnostics.CodeAnalysis;

namespace StarWars.AspNet.SWAPI.Extensions;

/// <summary>
/// Extension methods for an <see cref="Uri"/>.
/// </summary>
internal static class UriExtensions
{
    private const string PageQueryParamKey = "page";

    /// <summary>
    /// Extension method to parse the identifier from a <see cref="Uri"/>.
    /// </summary>
    /// <param name="url">The <see cref="Uri"/>.</param>
    /// <returns>The identifier parsed from the <see cref="Uri"/> or <see cref="string.Empty"/>.</returns>
    /// <remarks>This method is very specific to the current data provided by SWApi.</remarks>
    public static string ParseId(this Uri url)
    {
        var lastSegment = url.Segments.ToList().LastOrDefault();

        if (lastSegment is not null)
        {
            // Get everything but the last character because the `Uri` ends
            // each segment with `/`.
            return lastSegment[..^1];
        }

        return string.Empty;
    }

    /// <summary>
    /// Parse a query parameter value from a Uri. Does not throw an exception if
    /// the parameter can't be found.
    /// </summary>
    /// <param name="url">The <see cref="Uri"/>.</param>
    /// <param name="queryParameterKey">The query paramter key to search for.</param>
    /// <param name="result">
    /// When this method returns, contains the value of the requested query
    /// parameter. The parameter is passed uninitialized.
    /// </param>
    /// <returns><c>true</c> if the query parameter was parsed; otherwise, <c>false</c>.</returns>
    public static bool TryParseQueryParameter(this Uri url,
        string queryParameterKey,
        [NotNullWhen(true)] out string? result)
    {
        var query = url.ParseQueryParameter(queryParameterKey);
        if (query is not null)
        {
            result = query;
            return true;
        }
        result = null;
        return false;
    }

    /// <summary>
    /// Parse a page query parameter value from a Uri. Does not throw an exception if
    /// the parameter can't be found.
    /// </summary>
    /// <param name="uri">The <see cref="Uri"/>.</param>
    /// <param name="result">
    /// When this method returns, contains the value of the page query parameter.
    /// The parameter is passed uninitialized.
    /// </param>
    /// <returns><c>true</c> if the query parameter was parsed; otherwise, <c>false</c>.</returns>
    public static bool TryParsePageNumber(this Uri? uri,
        out int result)
    {
        if (uri is not null
            && uri.TryParseQueryParameter(PageQueryParamKey, out var pageNumberStr)
            && int.TryParse(pageNumberStr, out var pageNumber))
        {
            result = pageNumber;
            return true;
        }
        result = default;
        return false;
    }

    private static string? ParseQueryParameter(this Uri url,
        string queryParameterKey)
    {
        var queryParams = System.Web.HttpUtility.ParseQueryString(url.Query);
        var value = queryParams?.GetValues(queryParameterKey);
        if (value is not null)
        {
            // This only returns the first of the values from the collection.
            return value.FirstOrDefault();
        }
        return null;
    }
}
