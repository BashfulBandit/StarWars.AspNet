using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.People.Starships;

public class ListPersonStarshipsException
    : Exception
{
    private ListPersonStarshipsException(string message)
        : base(message)
    { }

    private ListPersonStarshipsException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public ListPersonStarshipsFailureReason FailureReason { get; init; } = ListPersonStarshipsFailureReason.Fault;

    public static ListPersonStarshipsException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = ListPersonStarshipsFailureReason.Fault
        };
    public static ListPersonStarshipsException NotFound(PersonId personId)
        => new($"Person not found for `{personId.Value}`.")
        {
            FailureReason = ListPersonStarshipsFailureReason.PersonNotFound
        };
}

public enum ListPersonStarshipsFailureReason
{
    Fault,

    PersonNotFound
}
