using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models.Filters;

public class SpeciesSearchFilter
    : SearchFilter
{
    public EpisodeId? EpisodeId { get; set; } = null;
}
