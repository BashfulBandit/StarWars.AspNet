using StarWars.AspNet.Core.Models.Filters;

namespace StarWars.AspNet.Core.Queries.Characters;

/// <summary>
/// Query to retrieve a page of <see cref="Models.Character"/> filtering and
/// sorting by the provided <see cref="Filter"/> property.
/// </summary>
public sealed class ListCharacters
    : IQuery<ListCharactersResult>
{
    /// <inheritdoc/>
    private ListCharacters(CharactersSearchFilter filter)
    {
        this.Filter = filter;
    }

    /// <summary>
    /// The filter containing the data to filter and sort the resources by.
    /// </summary>
    public CharactersSearchFilter Filter { get; } = default!;

    public static ListCharacters ToQuery(CharactersSearchFilter filter)
        => new(filter);
}
