using System.ComponentModel;
using FastEndpoints;

namespace StarWars.AspNet.Api.Requests;

/// <summary>
/// Define an abstract base page request for the Star Wars API.
/// </summary>
internal abstract class PageRequest
{
    public const int MinPage = 1;
    public const int MaxPageSize = 50;
    public const int DefaultPage = MinPage;
    public const int DefaultPageSize = 25;

    /// <summary>
    /// The page to retrieve.
    /// </summary>
    [QueryParam]
    [DefaultValue(DefaultPage)]
    public int Page { get; init; } = DefaultPage;

    /// <summary>
    /// The size of the page to retrieve.
    /// </summary>
    [QueryParam]
    [DefaultValue(DefaultPageSize)]
    public int PageSize { get; init; } = DefaultPageSize;
}
