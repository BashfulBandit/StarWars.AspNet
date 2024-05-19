using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models.Filters;

/// <summary>
/// Model to define and encapsulate what can be used to search for
/// <see cref="Starship"/> and the values to search by.
/// </summary>
public class StarshipsSearchFilter
    : SearchFilter
{
    /// <summary>
    /// Search for <see cref="Starship"/> on a <see cref="Character"/> the
    /// <see cref="PersonId"/> identifies.
    /// </summary>
    public CharacterId? PersonId { get; set; } = null;
}
