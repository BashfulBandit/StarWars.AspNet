namespace StarWars.AspNet.Core.Queries.Planets;

public sealed class CalculatePopulationResult
    : QueryResult
{
    private CalculatePopulationResult(ulong population)
        : base()
    {
        this.Population = population;
    }

    private CalculatePopulationResult(Exception error)
        : base(error)
    { }

    public ulong Population { get; set; } = 0;

    public static CalculatePopulationResult Failure(Exception error)
        => new(error);
    public static CalculatePopulationResult Success(ulong population)
        => new(population);
}
