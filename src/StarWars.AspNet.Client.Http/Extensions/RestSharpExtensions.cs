using RestSharp;
using StarWars.AspNet.Client.Exceptions;

namespace StarWars.AspNet.Client.Http.Extensions;

internal static class RestSharpExtensions
{
    public static StarWarsClientException BuildException(this RestResponse response)
    {
        var message = response.Content ?? "Error communicating with the StarWars API.";

        if (response.ErrorException is not null
            && response.ErrorException is not HttpRequestException)
        {
            return new StarWarsClientException(message, response.ErrorException);
        }

        return response.StatusCode switch
        {
            _ => new StarWarsClientException(message)
        };
    }
}
