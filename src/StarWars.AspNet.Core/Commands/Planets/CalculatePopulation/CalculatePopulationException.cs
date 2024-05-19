namespace StarWars.AspNet.Core.Commands.Planets;

/// <summary>
/// Thrown when <see cref="CalculatePopulation"/> operations fail.
/// </summary>
public class CalculatePopulationException
    : Exception
{
    /// <inheritdoc/>
    private CalculatePopulationException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
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

/// <summary>
/// An enumeration of potential failure reasons for the
/// <see cref="CalculatePopulation"/> operation.
/// </summary>
public enum CalculatePopulationFailureReason
{
    /// <summary>
    /// A general, unknown fault has occurred.
    /// </summary>
    Fault
}
