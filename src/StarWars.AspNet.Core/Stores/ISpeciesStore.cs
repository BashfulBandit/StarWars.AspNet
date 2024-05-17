using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Stores;

public interface ISpeciesStore
{
    Task<Species?> FetchAsync(SpeciesId id, CancellationToken cancellation = default);
}

public class SpeciesStoreException
    : Exception
{
    public SpeciesStoreException(string message)
        : base(message)
    { }

    public SpeciesStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

internal class NoOpSpeciesStore
    : ISpeciesStore
{
    public Task<Species?> FetchAsync(SpeciesId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
