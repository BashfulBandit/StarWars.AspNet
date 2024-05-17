using StarWars.AspNet.Core.Models.Filters;

namespace StarWars.AspNet.Core.Queries.Episodes.Species;

public sealed class ListEpisodeSpecies
    : IQuery<ListEpisodeSpeciesResult>
{
    private ListEpisodeSpecies(SpeciesSearchFilter filter)
    {
        this.Filter = filter;
    }

    public SpeciesSearchFilter Filter { get; } = default!;

    public static ListEpisodeSpecies ToQuery(SpeciesSearchFilter filter)
        => new(filter);
}
