using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

public interface IPlanetsStore
{
    Task<Planet?> FetchAsync(PlanetId id, CancellationToken cancellation = default);

    Task<IPage<Planet>> ListAsync(PlanetsSearchFilter filter, CancellationToken cancellation = default);
}

public class PlanetsStoreException
    : Exception
{
    public PlanetsStoreException(string message)
        : base(message)
    { }

    public PlanetsStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

internal class NoOpPlanetsStore
    : IPlanetsStore
{
    public Task<Planet?> FetchAsync(PlanetId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();

    public Task<IPage<Planet>> ListAsync(PlanetsSearchFilter filter, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
