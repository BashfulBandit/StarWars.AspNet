using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Characters.Starships;

/// <summary>
/// Thrown when <see cref="ListCharacterStarships"/> operations fail.
/// </summary>
public class ListCharacterStarshipsException
    : Exception
{
    /// <inheritdoc/>
    private ListCharacterStarshipsException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    private ListCharacterStarshipsException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public ListCharacterStarshipsFailureReason FailureReason { get; init; } = ListCharacterStarshipsFailureReason.Fault;

    public static ListCharacterStarshipsException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = ListCharacterStarshipsFailureReason.Fault
        };
    public static ListCharacterStarshipsException NotFound(CharacterId characterId)
        => new($"Character not found for `{characterId.Value}`.")
        {
            FailureReason = ListCharacterStarshipsFailureReason.CharacterNotFound
        };
}

/// <summary>
/// An enumeration of potential failure reasons for the
/// <see cref="ListCharacterStarships"/> operation.
/// </summary>
public enum ListCharacterStarshipsFailureReason
{
    /// <summary>
    /// A general, unknown fault has occurred.
    /// </summary>
    Fault,

    /// <summary>
    /// The requested character could not be found.
    /// </summary>
    CharacterNotFound
}
