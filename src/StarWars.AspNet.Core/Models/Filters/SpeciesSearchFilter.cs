using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models.Filters;

/// <summary>
/// Model to define and encapsulate what can be used to search for
/// <see cref="Species"/> and the values to search by.
/// </summary>
public class SpeciesSearchFilter
    : SearchFilter
{
    /// <summary>
    /// Search for <see cref="Species"/> on a <see cref="Episode"/> the
    /// <see cref="EpisodeId"/> identifies.
    /// </summary>
    public EpisodeId? EpisodeId { get; set; } = null;
}
