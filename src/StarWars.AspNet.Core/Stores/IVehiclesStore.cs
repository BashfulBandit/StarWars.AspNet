using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Stores;

public interface IVehiclesStore
{
    Task<Vehicle?> FetchAsync(VehicleId id, CancellationToken cancellation = default);
}

public class VehiclesStoreException
    : Exception
{
    public VehiclesStoreException(string message)
        : base(message)
    { }

    public VehiclesStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

internal class NoOpVehiclesStore
    : IVehiclesStore
{
    public Task<Vehicle?> FetchAsync(VehicleId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
