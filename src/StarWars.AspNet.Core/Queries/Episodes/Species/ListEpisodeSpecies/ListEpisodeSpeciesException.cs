using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Episodes.Species;

/// <summary>
/// Thrown when <see cref="ListEpisodeSpecies"/> operations fail.
/// </summary>
public class ListEpisodeSpeciesException
    : Exception
{
    /// <inheritdoc/>
    private ListEpisodeSpeciesException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    private ListEpisodeSpeciesException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public ListEpisodeSpeciesFailureReason FailureReason { get; init; } = ListEpisodeSpeciesFailureReason.Fault;

    public static ListEpisodeSpeciesException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = ListEpisodeSpeciesFailureReason.Fault
        };
    public static ListEpisodeSpeciesException NotFound(EpisodeId episodeId)
        => new($"Episode not found for `{episodeId.Value}`.")
        {
            FailureReason = ListEpisodeSpeciesFailureReason.EpisodeNotFound
        };
}

/// <summary>
/// An enumeration of potential failure reasons for the
/// <see cref="ListEpisodeSpecies"/> operation.
/// </summary>
public enum ListEpisodeSpeciesFailureReason
{
    /// <summary>
    /// A general, unknown fault has occurred.
    /// </summary>
    Fault,

    /// <summary>
    /// The episode could not be found.
    /// </summary>
    EpisodeNotFound
}
