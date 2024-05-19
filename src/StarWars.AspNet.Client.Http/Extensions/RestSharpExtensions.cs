using System.Net;
using RestSharp;
using StarWars.AspNet.Client.Exceptions;

namespace StarWars.AspNet.Client.Http.Extensions;

internal static class RestSharpExtensions
{
    /// <summary>
    /// Simple method to build a <see cref="StarWarsClientException"/> from a
    /// <see cref="RestResponse"/>.
    /// </summary>
    /// <param name="response">The <see cref="RestResponse"/>.</param>
    /// <returns>The built <see cref="StarWarsClientException"/>.</returns>
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
            HttpStatusCode.NotFound => new StarWarsClientNotFoundException(message),
            _ => new StarWarsClientException(message)
        };
    }
}
