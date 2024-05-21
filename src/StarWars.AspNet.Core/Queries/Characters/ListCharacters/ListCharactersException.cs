namespace StarWars.AspNet.Core.Queries.Characters;

/// <summary>
/// Thrown when <see cref="ListCharacters"/> operations fail.
/// </summary>
public class ListCharactersException
    : Exception
{
    /// <inheritdoc/>
    private ListCharactersException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public ListCharactersFailureReason FailureReason { get; init; } = ListCharactersFailureReason.Fault;

    public static ListCharactersException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = ListCharactersFailureReason.Fault
        };
}

/// <summary>
/// An enumeration of potential failure reasons for the
/// <see cref="ListCharacters"/> operation.
/// </summary>
public enum ListCharactersFailureReason
{
    /// <summary>
    /// A general, unknown fault has occurred.
    /// </summary>
    Fault
}
