using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Characters;

/// <summary>
/// Thrown when <see cref="FetchCharacterById"/> operations fail.
/// </summary>
public class FetchCharacterByIdException
    : Exception
{
    /// <inheritdoc/>
    private FetchCharacterByIdException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    private FetchCharacterByIdException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public FetchCharacterByIdFailureReason FailureReason { get; init; } = FetchCharacterByIdFailureReason.Fault;

    public static FetchCharacterByIdException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = FetchCharacterByIdFailureReason.Fault
        };
    public static FetchCharacterByIdException NotFound(CharacterId characterId)
        => new($"Character not found for `{characterId.Value}`.")
        {
            FailureReason = FetchCharacterByIdFailureReason.CharacterNotFound
        };
}

/// <summary>
/// An enumeration of potential failure reasons for the
/// <see cref="FetchCharacterById"/> operation.
/// </summary>
public enum FetchCharacterByIdFailureReason
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
