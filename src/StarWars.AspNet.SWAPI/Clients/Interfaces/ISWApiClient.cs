using SWApiClient.Exceptions;
using SWApiClient.Models;
using SWApiClient.Responses;

namespace SWApiClient.Interfaces;

/// <summary>
/// Interface for interacting with the Star Wars API.
/// </summary>
public interface ISWAPIClient
{
    /// <summary>
    /// Retrieve the home root discovery document that defines the resource
    /// endpoints.
    /// </summary>
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
    Task<DiscoveryResponse> DiscoveryAsync(CancellationToken cancellation = default);

    /// <summary>
    /// A client for interfacng with the <see cref="Person"/> resources.
    /// </summary>
    IPeopleClient People { get; }

    /// <summary>
    /// A client for interfacing with the <see cref="Film"/> resources.
    /// </summary>
    IFilmsClient Films { get; }

    /// <summary>
    /// A client for interfacing with the <see cref="Models.Species"/> resources.
    /// </summary>
    ISpeciesClient Species { get; }

    /// <summary>
    /// A client for interfacing with the <see cref="Planet"/> resources.
    /// </summary>
    IPlanetsClient Planets { get; }

    /// <summary>
    /// A client for interfacing with the <see cref="Starship"/> resources.
    /// </summary>
    IStarshipsClient Starships { get; }

    /// <summary>
    /// A client for interfacing with the <see cref="Vehicle"/> resources.
    /// </summary>
    IVehiclesClient Vehicles { get; }
}
