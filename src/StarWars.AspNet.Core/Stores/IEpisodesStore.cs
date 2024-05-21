using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

/// <summary>
/// Interface to provide operations for a store which manages <see cref="Episode"/>.
/// </summary>
public interface IEpisodesStore
{
    /// <summary>
    /// Retrieves a <see cref="Episode"/> by id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Episode"/> to retrieve.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The <see cref="Episode"/>.</returns>
    Task<Episode?> FetchAsync(EpisodeId id, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieves a paginated set of <see cref="Episode"/> with the filter applied.
    /// </summary>
    /// <param name="filter">The search filter.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>The paginated set of <see cref="Episode"/>.</returns>
    Task<IPage<Episode>> ListAsync(EpisodesSearchFilter filter, CancellationToken cancellation = default);
}

/// <summary>
/// An exception representing a failed operation against the <see cref="IEpisodesStore"/>.
/// </summary>
public class EpisodesStoreException
    : Exception
{
    /// <inheritdoc/>
    public EpisodesStoreException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public EpisodesStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// Basic NoOp implementation of <see cref="IEpisodesStore"/>.
/// </summary>
/// <remarks>
/// This is mostly just to ensure DI doesn't fail at startup. This is definitely
/// not necessary, but just something I have been doing.
/// </remarks>
internal class NoOpEpisodesStore
    : IEpisodesStore
{
    /// <inheritdoc/>
    public Task<Episode?> FetchAsync(EpisodeId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<IPage<Episode>> ListAsync(EpisodesSearchFilter filter, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
