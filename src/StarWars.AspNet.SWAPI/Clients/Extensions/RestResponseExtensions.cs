using System.Net;
using RestSharp;
using SWApiClient.Exceptions;

namespace SWApiClient.Extensions;

/// <summary>
/// Extension methods for a <see cref="RestResponse"/>.
/// </summary>
internal static class RestResponseExtensions
{
    /// <summary>
    /// Build a <see cref="SWAPIClientException"/> from the instance of <see cref="RestResponse"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="RestResponse"/>.</param>
    /// <returns>The built <see cref="SWAPIClientException"/>.</returns>
    public static SWAPIClientException BuildException(this RestResponse response)
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
