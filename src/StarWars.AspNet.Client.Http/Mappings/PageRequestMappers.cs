using RestSharp;
using StarWars.AspNet.Client.Requests;

namespace StarWars.AspNet.Client.Http.Mappings;

internal static class PageRequestMappers
{
    public static RestRequest AddQueryParameters(this RestRequest request,
        PageRequest pageRequest)
        => request.AddQueryParameter(PageRequest.PageQueryKey, pageRequest.Page)
            .AddQueryParameter(PageRequest.PageSizeQueryKey, pageRequest.PageSize);
}
