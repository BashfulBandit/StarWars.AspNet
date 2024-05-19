using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;

namespace StarWars.AspNet.Core.Stores;

/// <summary>
/// Interface to provide operations for a store which manages <see cref="Species"/>.
/// </summary>
public interface ISpeciesStore
{
    /// <summary>
    /// Retrieves a <see cref="Species"/> by id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Species"/> to retrieve.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The <see cref="Species"/>.</returns>
    Task<Species?> FetchAsync(SpeciesId id, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieves a paginated set of <see cref="Species"/> with the filter applied.
    /// </summary>
    /// <param name="filter">The search filter</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>The paginated set of <see cref="Species"/>.</returns>
    Task<IPage<Species>> ListAsync(SpeciesSearchFilter filter, CancellationToken cancellation = default);
}

/// <summary>
/// An exception representing a failed operation against the <see cref="ISpeciesStore"/>.
/// </summary>
public class SpeciesStoreException
    : Exception
{
    /// <inheritdoc/>
    public SpeciesStoreException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public SpeciesStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// Basic NoOp implementation of <see cref="ISpeciesStore"/>.
/// </summary>
/// <remarks>
/// This is mostly just to ensure DI doesn't fail at startup. This is definitely
/// not necessary, but just something I have been doing.
/// </remarks>
internal class NoOpSpeciesStore
    : ISpeciesStore
{
    /// <inheritdoc/>
    public Task<Species?> FetchAsync(SpeciesId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<IPage<Species>> ListAsync(SpeciesSearchFilter filter, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
