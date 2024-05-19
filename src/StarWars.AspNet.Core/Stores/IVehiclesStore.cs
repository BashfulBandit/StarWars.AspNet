using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Stores;

/// <summary>
/// Interface to provide operations for a store which manages <see cref="Vehicle"/>.
/// </summary>
public interface IVehiclesStore
{
    /// <summary>
    /// Retrieves a <see cref="Vehicle"/> by id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Vehicle"/> to retrieve.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The <see cref="Vehicle"/>.</returns>
    Task<Vehicle?> FetchAsync(VehicleId id, CancellationToken cancellation = default);
}

/// <summary>
/// An exception representing a failed operation against the <see cref="IVehiclesStore"/>.
/// </summary>
public class VehiclesStoreException
    : Exception
{
    /// <inheritdoc/>
    public VehiclesStoreException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public VehiclesStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// Basic NoOp implementation of <see cref="IVehiclesStore"/>.
/// </summary>
/// <remarks>
/// This is mostly just to ensure DI doesn't fail at startup. This is definitely
/// not necessary, but just something I have been doing.
/// </remarks>
internal class NoOpVehiclesStore
    : IVehiclesStore
{
    /// <inheritdoc/>
    public Task<Vehicle?> FetchAsync(VehicleId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
