using StarWars.AspNet.Core.Models.Filters;

namespace StarWars.AspNet.Core.Queries.Characters.Starships;

/// <summary>
/// Query to retrieve a page of <see cref="Models.Starship"/> for an
/// <see cref="Models.Character"/> filtering and sorting by the provided
/// <see cref="Filter"/> property.
/// </summary>
public sealed class ListCharacterStarships
    : IQuery<ListCharacterStarshipsResult>
{
    /// <inheritdoc/>
    private ListCharacterStarships(StarshipsSearchFilter filter)
    {
        this.Filter = filter;
    }

    /// <summary>
    /// The filter containing the data to filter and sort the resources by.
    /// </summary>
    public StarshipsSearchFilter Filter { get; } = default!;

    public static ListCharacterStarships ToQuery(StarshipsSearchFilter filter)
        => new(filter);
}
