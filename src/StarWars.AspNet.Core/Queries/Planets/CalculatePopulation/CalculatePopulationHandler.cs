using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Planets;

internal class CalculatePopulationHandler
    : IQueryHandler<CalculatePopulation, CalculatePopulationResult>
{
    private readonly IPlanetsStore _planetStore;

    public CalculatePopulationHandler(IPlanetsStore planetStore)
    {
        this._planetStore = planetStore;
    }

    public async Task<CalculatePopulationResult> HandleAsync(CalculatePopulation query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var population = ulong.MinValue;
            var page = await this._planetStore.ListAsync(new()
            {
                Page = 1,
                // Just grab as much as possible for the request. This
                // is meant as a performance gain. If we ever end up will an bug
                // because there are more planets than a int.MaxValue, this will
                // need to be adjusted. Likely where it iterates over the pages.
                PageSize = int.MaxValue
            }, cancellation);

            foreach (var planet in page.Items)
            {
                if (planet.Population.HasValue)
                {
                    population += planet.Population.Value;
                }
            }
            return CalculatePopulationResult.Success(population);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return CalculatePopulationResult.Failure(CalculatePopulationException.Fault("Failed to calculate the Star Wars universes population.", ex));
        }
    }
}

