namespace StarWars.AspNet.Client.Requests.Characters;

/// <summary>
/// A request to retrieve a paginated list of <see cref="Models.Character"/>
/// </summary>
public class ListCharactersRequest
    : PageRequest
{
    /// <summary>
    /// An optional field to filter the results by the <see cref="Models.Character.Name"/>
    /// property.
    /// </summary>
    public string? Name { get; set; } = default!;
}
