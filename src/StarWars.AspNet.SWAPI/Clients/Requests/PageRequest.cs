namespace SWApiClient.Requests;

/// <summary>
/// Abstract base request for a list endpoint.
/// </summary>
public abstract class PageRequest
{
    /// <summary>
    /// Default value for the <see cref="Page"/> value if one isn't provided.
    /// </summary>
    public const int DefaultPage = 1;

    /// <summary>
    /// The page number being requested.
    /// </summary>
    public int Page { get; set; } = DefaultPage;

    /// <summary>
    /// Term to search the list endpoint by.
    /// </summary>
    public string? Search { get; set; } = null;
}
