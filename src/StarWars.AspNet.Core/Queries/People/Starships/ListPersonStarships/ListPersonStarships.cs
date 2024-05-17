using StarWars.AspNet.Core.Models.Filters;

namespace StarWars.AspNet.Core.Queries.People.Starships;

public sealed class ListPersonStarships
    : IQuery<ListPersonStarshipsResult>
{
    private ListPersonStarships(StarshipsSearchFilter filter)
    {
        this.Filter = filter;
    }

    public StarshipsSearchFilter Filter { get; } = default!;

    public static ListPersonStarships ToQuery(StarshipsSearchFilter filter)
        => new(filter);
}
