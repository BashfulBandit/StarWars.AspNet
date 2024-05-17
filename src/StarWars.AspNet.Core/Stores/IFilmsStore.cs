using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

public interface IFilmsStore
{
    Task<Film?> FetchAsync(FilmId id, CancellationToken cancellation = default);
}

public class FilmsStoreException
    : Exception
{
    public FilmsStoreException(string message)
        : base(message)
    { }

    public FilmsStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

internal class NoOpFilmsStore
    : IFilmsStore
{
    public Task<Film?> FetchAsync(FilmId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
