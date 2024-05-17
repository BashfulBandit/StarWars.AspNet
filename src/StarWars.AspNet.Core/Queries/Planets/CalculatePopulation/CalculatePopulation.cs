namespace StarWars.AspNet.Core.Queries.Planets;

public sealed class CalculatePopulation
    : IQuery<CalculatePopulationResult>
{
    private CalculatePopulation()
    { }

    public static CalculatePopulation ToQuery()
        => new();
}
