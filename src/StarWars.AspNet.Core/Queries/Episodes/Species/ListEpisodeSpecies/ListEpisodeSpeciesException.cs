using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Episodes.Species;

public class ListEpisodeSpeciesException
    : Exception
{
    private ListEpisodeSpeciesException(string message)
        : base(message)
    { }

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

public enum ListEpisodeSpeciesFailureReason
{
    Fault,

    EpisodeNotFound
}
