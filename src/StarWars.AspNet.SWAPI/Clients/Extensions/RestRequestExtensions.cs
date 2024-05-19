using RestSharp;
using StarWars.AspNet.Core.Extensions;
using SWApiClient.Requests;

namespace SWApiClient.Extensions;

/// <summary>
/// Extension methods for a <see cref="RestRequest"/> for altering an instance.
/// </summary>
internal static class RestRequestExtensions
{
    private const string PageQueryKey = "page";
    private const string SearchQueryKey = "search";

    /// <summary>
    /// Extension method to add the query parameters to the <see cref="RestRequest"/>
    /// from the data provided in the <see cref="PageRequest"/>.
    /// </summary>
    /// <param name="request">The intance of <see cref="RestRequest"/> to add the query parameters to.</param>
    /// <param name="pageRequest">The provided <see cref="PageRequest"/> to provide the values for the query parameters.</param>
    /// <returns></returns>
    public static RestRequest AddQueryParameters(this RestRequest request,
        PageRequest pageRequest)
    {
        request = request.AddQueryParameter(PageQueryKey, pageRequest.Page);
        if (pageRequest.Search.IsPresent())
        {
            request = request.AddQueryParameter(SearchQueryKey, pageRequest.Search);
        }
        return request;
    }
}
