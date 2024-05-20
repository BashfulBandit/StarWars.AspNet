namespace StarWars.AspNet.Core.Models.Filters;

/// <summary>
/// Model to define and encapsulate what can be used to search for
/// <see cref="Character"/> and the values to search by.
/// </summary>
public class CharactersSearchFilter
    : SearchFilter
{
    /// <summary>
    /// Search for <see cref="Character"/> by the provided <see cref="Name"/>
    /// property.
    /// </summary>
    public string? Name { get; set; } = null;
}
