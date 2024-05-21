using StarWars.AspNet.Core.Models.Filters;

namespace StarWars.AspNet.Core.Queries.Episodes;

/// <summary>
/// Query to retrieve a page of <see cref="Models.Episode"/> filtering and
/// sorting by the provided <see cref="Filter"/> property.
/// </summary>
public sealed class ListEpisodes
    : IQuery<ListEpisodesResult>
{
    /// <inheritdoc/>
    private ListEpisodes(EpisodesSearchFilter filter)
    {
        this.Filter = filter;
    }

    /// <summary>
    /// The filter containing the data to filter and sort the resources by.
    /// </summary>
    public EpisodesSearchFilter Filter { get; } = default!;

    public static ListEpisodes ToQuery(EpisodesSearchFilter filter)
        => new(filter);
}
