using System.ComponentModel;
using FastEndpoints;

namespace StarWars.AspNet.Api.Requests;

internal abstract class PageRequest
{
    public const int MinPage = 1;
    public const int MaxPageSize = 50;
    public const int DefaultPage = MinPage;
    public const int DefaultPageSize = 25;

    [QueryParam]
    [DefaultValue(DefaultPage)]
    public int Page { get; init; } = DefaultPage;

    [QueryParam]
    [DefaultValue(DefaultPageSize)]
    public int PageSize { get; init; } = DefaultPageSize;
}
