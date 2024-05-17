using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Models;
using StarWars.AspNet.SWAPI.Clients.Requests.Species;
using StarWars.AspNet.SWAPI.Clients.Responses.Species;

namespace StarWars.AspNet.SWAPI.Clients.Interfaces;

/// <summary>
/// Interface for interacting with the <see cref="Species"/> resources.
/// </summary>
internal interface ISpeciesClient
{
    /// <summary>
    /// Retrieve a pagination list of <see cref="Species"/> resources.
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
    Task<ListSpeciesResponse> ListAsync(ListSpeciesRequest? request = null, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieve a specific <see cref="Species"/> by it's identifier.
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
    Task<RetrieveSpeciesResponse> RetrieveAsync(RetrieveSpeciesRequest request, CancellationToken cancellation = default);
}
