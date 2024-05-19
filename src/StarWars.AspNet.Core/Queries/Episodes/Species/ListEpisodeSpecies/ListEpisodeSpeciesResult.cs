using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Queries.Episodes.Species;

/// <summary>
/// The result of executing a <see cref="ListEpisodeSpecies"/> query.
/// </summary>
public sealed class ListEpisodeSpeciesResult
    : QueryResult
{
    /// <inheritdoc/>
    private ListEpisodeSpeciesResult(IPage<Models.Species> page)
        : base()
    {
        this.Page = page;
    }

    /// <inheritdoc/>
    private ListEpisodeSpeciesResult(Exception error)
        : base(error)
    { }

    /// <summary>
    /// A page of the retrieved <see cref="Models.Species"/>.
    /// </summary>
    public IPage<Models.Species>? Page { get; init; } = default;

    public static ListEpisodeSpeciesResult Failure(Exception error)
        => new(error);
    public static ListEpisodeSpeciesResult Success(IPage<Models.Species> page)
        => new(page);
}
