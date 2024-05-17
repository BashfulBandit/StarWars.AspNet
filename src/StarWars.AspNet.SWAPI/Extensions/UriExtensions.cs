using System.Diagnostics.CodeAnalysis;

namespace StarWars.AspNet.SWAPI.Extensions;

internal static class UriExtensions
{
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

    public static bool TryParseQueryParameter(this Uri url,
        string queryParameter,
        [NotNullWhen(true)] out string? value)
    {
        var query = url.ParseQueryParameter(queryParameter);
        if (query is not null)
        {
            value = query;
            return true;
        }
        value = null;
        return false;
    }

    public static string? ParseQueryParameter(this Uri url,
        string queryParameter)
    {
        var queryParams = System.Web.HttpUtility.ParseQueryString(url.Query);
        var value = queryParams?.GetValues(queryParameter);
        if (value is not null)
        {
            // This only returns the first of the values from the collection.
            return value.FirstOrDefault();
        }
        return null;
    }
}
