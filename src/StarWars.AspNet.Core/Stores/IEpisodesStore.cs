using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

public interface IEpisodesStore
{
    Task<Episode?> FetchAsync(EpisodeId id, CancellationToken cancellation = default);
}

public class EpisodesStoreException
    : Exception
{
    public EpisodesStoreException(string message)
        : base(message)
    { }

    public EpisodesStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

internal class NoOpEpisodesStore
    : IEpisodesStore
{
    public Task<Episode?> FetchAsync(EpisodeId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
