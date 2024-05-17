using System.Diagnostics.CodeAnalysis;

namespace StarWars.AspNet.Core.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Determines if the <paramref name="candidate"/> string is <c>null</c> or
    /// whitespace.
    /// </summary>
    /// <param name="candidate">The candidate string.</param>
    /// <returns>True if <c>null</c> or whitespace; otherwise, false.</returns>
    public static bool IsEmpty([NotNullWhen(false)] this string? candidate)
        => string.IsNullOrWhiteSpace(candidate);

    /// <summary>
    /// Determines if the <paramref name="candidate"/> string is not <c>null</c> or
    /// whitespace.
    /// </summary>
    /// <param name="candidate">The candidate string.</param>
    /// <returns>True if not <c>null</c> or whitespace; otherwise, false.</returns>
    public static bool IsPresent([NotNullWhen(true)] this string? candidate)
        => !candidate.IsEmpty();

    /// <summary>
    /// Determines if the <paramref name="candidate"/> string is <c>null</c> or
    /// whitespace.
    /// </summary>
    /// <param name="candidate">The candidate string.</param>
    /// <returns>True if <c>null</c> or whitespace; otherwise, false.</returns>
    public static bool IsMissing([NotNullWhen(false)] this string? candidate)
        => candidate.IsEmpty();
}
