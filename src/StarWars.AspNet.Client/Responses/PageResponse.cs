using StarWars.AspNet.Client.Models;

namespace StarWars.AspNet.Client.Responses;

/// <summary>
/// Abstract response for page responses to carry pagination metadata.
/// </summary>
public abstract class PageResponse
{
    /// <summary>
    /// The pagination metadata.
    /// </summary>
    public Pagination Pagination { get; set; } = default!;
}
