namespace StarWars.AspNet.Api.Requests.Characters;

/// <summary>
/// Request to retrieve a paginated list of characters from the Star Wars universe.
/// </summary>
internal class ListCharactersRequest
    : PageRequest
{
    /// <summary>
    /// Filter the list by the <see cref="Models.CharacterDto.Name"/> property.
    /// </summary>
    public string? Name { get; set; } = default;
}
