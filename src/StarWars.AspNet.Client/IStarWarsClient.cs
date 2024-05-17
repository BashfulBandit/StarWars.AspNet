using StarWars.AspNet.Client.Exceptions;
using StarWars.AspNet.Client.Requests.Episodes.Species;
using StarWars.AspNet.Client.Requests.People.Starships;
using StarWars.AspNet.Client.Responses;
using StarWars.AspNet.Client.Responses.Episodes.Species;
using StarWars.AspNet.Client.Responses.People.Starships;

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

    IEpisodesClient Episodes { get; }

    IPeopleClient People { get; }

    public interface IEpisodesClient
    {
        ISpeciesClient Species { get; }

        public interface ISpeciesClient
        {
            Task<ListEpisodeSpeciesResponse> ListAsync(ListEpisodeSpeciesRequest request, CancellationToken cancellation = default);
        }
    }

    public interface IPeopleClient
    {
        IStarshipsClient Starships { get; }

        public interface IStarshipsClient
        {
            Task<ListPersonStarshipsResponse> ListAsync(ListPersonStarshipsRequest request, CancellationToken cancellation = default);
        }
    }
}
