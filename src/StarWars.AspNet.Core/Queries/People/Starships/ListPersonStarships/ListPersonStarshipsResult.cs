using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Queries.People.Starships;

public sealed class ListPersonStarshipsResult
    : QueryResult
{
    private ListPersonStarshipsResult(IPage<Starship> page)
        : base()
    {
        this.Page = page;
    }

    private ListPersonStarshipsResult(Exception error)
        : base(error)
    { }

    public IPage<Starship>? Page { get; init; } = null;

    public static ListPersonStarshipsResult Failure(Exception error)
        => new(error);
    public static ListPersonStarshipsResult Success(IPage<Starship> page)
        => new(page);
}
