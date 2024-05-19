namespace StarWars.AspNet.Core.Commands.Planets;

/// <summary>
/// Command to calculate the population of the known Star Wars universe.
/// </summary>
public sealed class CalculatePopulation
    : ICommand<CalculatePopulationResult>
{
    /// <inheritdoc/>
    private CalculatePopulation()
    { }

    public static CalculatePopulation ToCommand()
        => new();
}
