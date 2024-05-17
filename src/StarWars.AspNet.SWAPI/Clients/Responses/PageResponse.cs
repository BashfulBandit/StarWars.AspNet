namespace StarWars.AspNet.SWAPI.Clients.Responses;

/// <summary>
/// Abstract base response for a list endpoint.
/// </summary>
/// <typeparam name="T"></typeparam>
internal abstract class PageResponse<T>
{
    /// <summary>
    /// Count of total resources in the API.
    /// </summary>
    public int Count { get; set; } = default;

    /// <summary>
    /// The hypermedia URL of the next page of the resources.
    /// </summary>
    public Uri? Next { get; set; } = default;

    /// <summary>
    /// The hypermedia URL of the previous page of the resources.
    /// </summary>
    public Uri? Previous { get; set; } = default;

    /// <summary>
    /// Collection of retrieved <typeparamref name="T"/>.
    /// </summary>
    public IEnumerable<T> Results { get; set; } = default!;
}
