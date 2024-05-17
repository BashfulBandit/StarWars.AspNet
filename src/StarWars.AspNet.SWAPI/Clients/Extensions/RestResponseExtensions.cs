using System.Net;
using RestSharp;
using StarWars.AspNet.SWAPI.Clients.Exceptions;

namespace StarWars.AspNet.SWAPI.Clients.Extensions;

internal static class RestResponseExtensions
{
    public static SWAPIClientException BuildExceptionFromResponse(this RestResponse response)
    {
        var message = response.Content ?? "Error communicating with the Star Wars API.";

        if (response.ErrorException is not null
            && response.ErrorException is not HttpRequestException)
        {
            return new SWAPIClientException(message, response.ErrorException);
        }

        return response.StatusCode switch
        {
            HttpStatusCode.NotFound => new SWAPIClientNotFoundException(message),
            _ => new SWAPIClientException(message)
        };
    }
}
