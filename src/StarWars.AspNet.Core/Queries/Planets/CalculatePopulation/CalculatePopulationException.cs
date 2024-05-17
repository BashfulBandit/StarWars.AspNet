namespace StarWars.AspNet.Core.Queries.Planets;

public class CalculatePopulationException
    : Exception
{
    private CalculatePopulationException(string message)
        : base(message)
    { }

    private CalculatePopulationException(string message,
        Exception innerException)
        : base(message, innerException)
    { }

    public CalculatePopulationFailureReason FailureReason { get; init; } = CalculatePopulationFailureReason.Fault;

    public static CalculatePopulationException Fault(string message,
        Exception innerException)
        => new(message, innerException)
        {
            FailureReason = CalculatePopulationFailureReason.Fault
        };
}

public enum CalculatePopulationFailureReason
{
    Fault
}
