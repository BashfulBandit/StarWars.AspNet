using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Episodes;

/// <summary>
/// Query to retrieve a <see cref="Models.Episode"/> by the provided identifier.
/// </summary>
public sealed class FetchEpisodeById
    : IQuery<FetchEpisodeByIdResult>
{
    private FetchEpisodeById(EpisodeId episodeId)
    {
        this.EpisodeId = episodeId;
    }

    /// <summary>
    /// The provided identifier.
    /// </summary>
    public EpisodeId EpisodeId { get; } = default!;

    public static FetchEpisodeById ToQuery(EpisodeId episodeId)
        => new(episodeId);
}
