namespace StarWars.AspNet.Core.Commands.Planets;

/// <summary>
/// The result of executing a <see cref="CalculatePopulation"/> command.
/// </summary>
public sealed class CalculatePopulationResult
    : CommandResult
{
    /// <inheritdoc/>
    private CalculatePopulationResult(ulong population)
        : base()
    {
        this.Population = population;
    }

    /// <inheritdoc/>
    private CalculatePopulationResult(Exception error)
        : base(error)
    { }

    /// <summary>
    /// The population calculated from processing the <see cref="CalculatePopulation"/> command.
    /// </summary>
    public ulong Population { get; set; } = 0;

    public static CalculatePopulationResult Failure(Exception error)
        => new(error);
    public static CalculatePopulationResult Success(ulong population)
        => new(population);
}
