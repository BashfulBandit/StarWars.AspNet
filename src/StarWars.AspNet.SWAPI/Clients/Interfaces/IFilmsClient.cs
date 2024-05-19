using SWApiClient.Exceptions;
using SWApiClient.Models;
using SWApiClient.Requests.Films;
using SWApiClient.Responses.Films;

namespace SWApiClient.Interfaces;

/// <summary>
/// Interface for interacting with the <see cref="Film"/> resources.
/// </summary>
public interface IFilmsClient
{
    /// <summary>
    /// Retrieve a pagination list of <see cref="Film"/> resources.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The response.</returns>
    /// <exception cref="SWAPIClientException">
    /// An exception thrown when an unknown error occurs during the processing
    /// the request and response.
    /// </exception>
    Task<ListFilmsResponse> ListAsync(ListFilmsRequest? request = null, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieve a specific <see cref="Person"/> by it's identifier.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The response.</returns>
    /// <exception cref="SWAPIClientException">
    /// An exception thrown when an unknown error occurs during the processing
    /// the request and response.
    /// </exception>
    /// <exception cref="SWAPIClientNotFoundException">
    /// An exception thrown when the server returned a HTTP 404 - Not Found.
    /// </exception>
    Task<RetrieveFilmResponse> RetrieveAsync(RetrieveFilmRequest request, CancellationToken cancellation = default);
}
