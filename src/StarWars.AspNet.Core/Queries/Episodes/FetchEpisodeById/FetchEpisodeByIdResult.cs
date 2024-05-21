using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Episodes;

/// <summary>
/// The result of executing a <see cref="FetchEpisodeById"/> query.
/// </summary>
public sealed class FetchEpisodeByIdResult
    : QueryResult
{
    /// <inheritdoc/>
    private FetchEpisodeByIdResult(Episode episode)
        : base()
    {
        this.Episode = episode;
    }

    /// <inheritdoc/>
    private FetchEpisodeByIdResult(Exception error)
        : base(error)
    { }

    /// <summary>
    /// The retrieved <see cref="Models.Episode"/>.
    /// </summary>
    public Episode? Episode { get; init; } = null;

    public static FetchEpisodeByIdResult Failure(Exception error)
        => new(error);
    public static FetchEpisodeByIdResult Success(Episode episode)
        => new(episode);
    public static FetchEpisodeByIdResult NotFound(EpisodeId episodeId)
        => Failure(FetchEpisodeByIdException.NotFound(episodeId));
}
