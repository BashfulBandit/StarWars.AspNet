namespace StarWars.AspNet.Core.Queries.Episodes;

/// <summary>
/// Thrown when <see cref="ListEpisodes"/> operations fail.
/// </summary>
public class ListEpisodesException
    : Exception
{
    /// <inheritdoc/>
    private ListEpisodesException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public ListEpisodesFailureReason FailureReason { get; init; } = ListEpisodesFailureReason.Fault;

    public static ListEpisodesException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = ListEpisodesFailureReason.Fault
        };
}

/// <summary>
/// An enumeration of potential failure reasons for the
/// <see cref="ListEpisodes"/> operation.
/// </summary>
public enum ListEpisodesFailureReason
{
    /// <summary>
    /// A general, unknown fault has occurred.
    /// </summary>
    Fault
}
