using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Episodes;

/// <summary>
/// Thrown when <see cref="FetchEpisodeById"/> operations fail.
/// </summary>
public class FetchEpisodeByIdException
    : Exception
{
    /// <inheritdoc/>
    private FetchEpisodeByIdException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    private FetchEpisodeByIdException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public FetchEpisodeByIdFailureReason FailureReason { get; init; } = FetchEpisodeByIdFailureReason.Fault;

    public static FetchEpisodeByIdException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = FetchEpisodeByIdFailureReason.Fault
        };
    public static FetchEpisodeByIdException NotFound(EpisodeId episodeId)
        => new($"Episode not found for `{episodeId.Value}`.")
        {
            FailureReason = FetchEpisodeByIdFailureReason.EpisodeNotFound
        };
}

/// <summary>
/// An enumeration of potential failure reasons for the
/// <see cref="FetchCharacterById"/> operation.
/// </summary>
public enum FetchEpisodeByIdFailureReason
{
    /// <summary>
    /// A general, unknown fault has occurred.
    /// </summary>
    Fault,

    /// <summary>
    /// The requested character could not be found.
    /// </summary>
    EpisodeNotFound
}
