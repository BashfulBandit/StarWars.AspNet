using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

public interface IStarshipsStore
{
    Task<Starship?> FetchAsync(StarshipId id, CancellationToken cancellation = default);

    Task<IPage<Starship>> ListAsync(StarshipsSearchFilter filter, CancellationToken cancellation = default);
}

public class StarshipsStoreException
    : Exception
{
    public StarshipsStoreException(string message)
        : base(message)
    { }

    public StarshipsStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

internal class NoOpStarshipsStore
    : IStarshipsStore
{
    public Task<Starship?> FetchAsync(StarshipId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();

    public Task<IPage<Starship>> ListAsync(StarshipsSearchFilter filter, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
