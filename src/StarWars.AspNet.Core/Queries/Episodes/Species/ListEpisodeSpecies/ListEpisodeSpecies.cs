using StarWars.AspNet.Core.Models.Filters;

namespace StarWars.AspNet.Core.Queries.Episodes.Species;

/// <summary>
/// Query to retrieve a page of <see cref="Models.Species"/> for an
/// <see cref="Models.Episode"/> filtering and sorting by the provided
/// <see cref="Filter"/> property.
/// </summary>
public sealed class ListEpisodeSpecies
    : IQuery<ListEpisodeSpeciesResult>
{
    /// <inheritdoc/>
    private ListEpisodeSpecies(SpeciesSearchFilter filter)
    {
        this.Filter = filter;
    }

    /// <summary>
    /// The filter containing the data to filter and sort the resources by.
    /// </summary>
    public SpeciesSearchFilter Filter { get; } = default!;

    public static ListEpisodeSpecies ToQuery(SpeciesSearchFilter filter)
        => new(filter);
}
