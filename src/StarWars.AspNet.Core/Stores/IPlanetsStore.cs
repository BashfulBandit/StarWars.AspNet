using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

/// <summary>
/// Interface to provide operations for a store which manages <see cref="Planet"/>.
/// </summary>
public interface IPlanetsStore
{
    /// <summary>
    /// Retrieves a <see cref="Planet"/> by id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Planet"/> to retrieve.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The <see cref="Planet"/>.</returns>
    Task<Planet?> FetchAsync(PlanetId id, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieves a paginated set of <see cref="Planet"/> with the filter applied.
    /// </summary>
    /// <param name="filter">The search filter</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>The paginated set of <see cref="Planet"/>.</returns>
    Task<IPage<Planet>> ListAsync(PlanetsSearchFilter filter, CancellationToken cancellation = default);
}

/// <summary>
/// An exception representing a failed operation against the <see cref="IPlanetsStore"/>.
/// </summary>
public class PlanetsStoreException
    : Exception
{
    /// <inheritdoc/>
    public PlanetsStoreException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public PlanetsStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// Basic NoOp implementation of <see cref="IPlanetsStore"/>.
/// </summary>
/// <remarks>
/// This is mostly just to ensure DI doesn't fail at startup. This is definitely
/// not necessary, but just something I have been doing.
/// </remarks>
internal class NoOpPlanetsStore
    : IPlanetsStore
{
    /// <inheritdoc/>
    public Task<Planet?> FetchAsync(PlanetId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<IPage<Planet>> ListAsync(PlanetsSearchFilter filter, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
