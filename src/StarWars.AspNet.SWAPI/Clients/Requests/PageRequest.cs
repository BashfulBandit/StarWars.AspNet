namespace StarWars.AspNet.SWAPI.Clients.Requests;

/// <summary>
/// Abstract base request for a list endpoint.
/// </summary>
internal abstract class PageRequest
{
    public const int DefaultPage = 1;

    public int Page { get; set; } = DefaultPage;

    /// <summary>
    /// Term to search the list endpoint by.
    /// </summary>
    public string? Search { get; set; } = null;
}
