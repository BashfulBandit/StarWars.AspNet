using StarWars.AspNet.Client.Exceptions;
using StarWars.AspNet.Client.Requests.Characters.Starships;
using StarWars.AspNet.Client.Requests.Episodes.Species;
using StarWars.AspNet.Client.Responses;
using StarWars.AspNet.Client.Responses.Characters.Starships;
using StarWars.AspNet.Client.Responses.Episodes.Species;

namespace StarWars.AspNet.Client;

/// <summary>
/// Interface for interacting with the Star Wars API.
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

    /// <summary>
    /// Method to retrieve the known population of the Star Wars universe from
    /// the Star Wars API.
    /// </summary>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>The <see cref="GetPopulationResponse"/> on success.</returns>
    /// <exception cref="StarWarsClientException"></exception>
    Task<GetPopulationResponse> GetPopulationAsync(CancellationToken cancellation = default);

    /// <summary>
    /// A client for interfacng with the episode resources.
    /// </summary>
    IEpisodesClient Episodes { get; }

    /// <summary>
    /// A client for interfacng with the character resources.
    /// </summary>
    ICharactersClient People { get; }

    /// <summary>
    /// Interface for interacting with episode resources in the Star Wars API.
    /// </summary>
    public interface IEpisodesClient
    {
        /// <summary>
        /// A client for interfacing with an episode's species.
        /// </summary>
        ISpeciesClient Species { get; }

        /// <summary>
        /// Interface for interacting with an episode's <see cref="Models.Species"/>.
        /// </summary>
        public interface ISpeciesClient
        {
            /// <summary>
            /// Retrieve a paginated list <see cref="Models.Species"/> for an episode.
            /// </summary>
            /// <param name="request">The <see cref="ListEpisodeSpeciesRequest"/>.</param>
            /// <param name="cancellation">
            /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
            /// </param>
            /// <returns>The <see cref="ListEpisodeSpeciesResponse"/>.</returns>
            /// <exception cref="StarWarsClientException"></exception>
            /// <exception cref="StarWarsClientNotFoundException"></exception>
            Task<ListEpisodeSpeciesResponse> ListAsync(ListEpisodeSpeciesRequest request, CancellationToken cancellation = default);
        }
    }

    /// <summary>
    /// Interface for interacting with character resources in the Star Wars API.
    /// </summary>
    public interface ICharactersClient
    {
        /// <summary>
        /// A client for interfacing with an character's starships.
        /// </summary>
        IStarshipsClient Starships { get; }

        /// <summary>
        /// Interface for interacting with an character's <see cref="Models.Starship"/>.
        /// </summary>
        public interface IStarshipsClient
        {
            /// <summary>
            /// Retrieve a paginated list <see cref="Models.Starship"/> for an episode.
            /// </summary>
            /// <param name="request">The <see cref="ListCharacterStarshipsRequest"/>.</param>
            /// <param name="cancellation">
            /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
            /// </param>
            /// <returns>The <see cref="ListCharacterStarshipsResponse"/>.</returns>
            /// <exception cref="StarWarsClientException"></exception>
            /// <exception cref="StarWarsClientNotFoundException"></exception>
            Task<ListCharacterStarshipsResponse> ListAsync(ListCharacterStarshipsRequest request, CancellationToken cancellation = default);
        }
    }
}
