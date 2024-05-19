using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

/// <summary>
/// Interface to provide operations for a store which manages <see cref="Starship"/>.
/// </summary>
public interface IStarshipsStore
{
    /// <summary>
    /// Retrieves a <see cref="Starship"/> by id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Starship"/> to retrieve.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The <see cref="Starship"/>.</returns>
    Task<Starship?> FetchAsync(StarshipId id, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieves a paginated set of <see cref="Starship"/> with the filter applied.
    /// </summary>
    /// <param name="filter">The search filter</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>The paginated set of <see cref="Starship"/>.</returns>
    Task<IPage<Starship>> ListAsync(StarshipsSearchFilter filter, CancellationToken cancellation = default);
}

/// <summary>
/// An exception representing a failed operation against the <see cref="IStarshipsStore"/>.
/// </summary>
public class StarshipsStoreException
    : Exception
{
    /// <inheritdoc/>
    public StarshipsStoreException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public StarshipsStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// Basic NoOp implementation of <see cref="IStarshipsStore"/>.
/// </summary>
/// <remarks>
/// This is mostly just to ensure DI doesn't fail at startup. This is definitely
/// not necessary, but just something I have been doing.
/// </remarks>
internal class NoOpStarshipsStore
    : IStarshipsStore
{
    /// <inheritdoc/>
    public Task<Starship?> FetchAsync(StarshipId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<IPage<Starship>> ListAsync(StarshipsSearchFilter filter, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
