using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Queries.Episodes.Species;

public sealed class ListEpisodeSpeciesResult
    : QueryResult
{
    private ListEpisodeSpeciesResult(IPage<Models.Species> page)
        : base()
    {
        this.Page = page;
    }

    private ListEpisodeSpeciesResult(Exception error)
        : base(error)
    { }

    public IPage<Models.Species>? Page { get; init; } = null;

    public static ListEpisodeSpeciesResult Failure(Exception error)
        => new(error);
    public static ListEpisodeSpeciesResult Success(IPage<Models.Species> page)
        => new(page);
}
