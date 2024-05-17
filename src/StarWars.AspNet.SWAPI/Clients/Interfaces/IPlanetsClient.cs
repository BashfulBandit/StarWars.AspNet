using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Models;
using StarWars.AspNet.SWAPI.Clients.Requests.Planets;
using StarWars.AspNet.SWAPI.Clients.Responses.Planets;

namespace StarWars.AspNet.SWAPI.Clients.Interfaces;

/// <summary>
/// Interface for interacting with the <see cref="Planet"/> resources.
/// </summary>
internal interface IPlanetsClient
{
    /// <summary>
    /// Retrieve a pagination list of <see cref="Planet"/> resources.
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
    Task<ListPlanetsResponse> ListAsync(ListPlanetsRequest? request = null, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieve a specific <see cref="Planet"/> by it's identifier.
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
    Task<RetrievePlanetResponse> RetrieveAsync(RetrievePlanetRequest request, CancellationToken cancellation = default);
}
