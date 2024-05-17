using StarWars.AspNet.Client.Exceptions;
using StarWars.AspNet.Client.Responses;

namespace StarWars.AspNet.Client;

/// <summary>
/// Interface for interacting with the StarWars.AspNet.Api.
/// </summary>
public interface IStarWarsClient
{
    /// <summary>
    /// Method to check the health status of the API.
    /// </summary>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <exception cref="StarWarsClientException"></exception>
    Task HealthCheckAsync(CancellationToken cancellation = default);

    Task<GetPopulationResponse> GetPopulationAsync(CancellationToken cancellation = default);
}
