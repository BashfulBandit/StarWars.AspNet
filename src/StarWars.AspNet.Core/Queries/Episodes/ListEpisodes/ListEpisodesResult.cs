using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Queries.Episodes;

/// <summary>
/// The result of executing a <see cref="ListEpisodes"/> query.
/// </summary>
public sealed class ListEpisodesResult
    : QueryResult
{
    /// <inheritdoc/>
    private ListEpisodesResult(IPage<Episode> page)
        : base()
    {
        this.Page = page;
    }

    /// <inheritdoc/>
    private ListEpisodesResult(Exception error)
        : base(error)
    { }

    /// <summary>
    /// A page of the retrieved <see cref="Episode"/>.
    /// </summary>
    public IPage<Episode>? Page { get; init; } = null;

    public static ListEpisodesResult Failure(Exception error)
        => new(error);
    public static ListEpisodesResult Success(IPage<Episode> page)
        => new(page);
}
