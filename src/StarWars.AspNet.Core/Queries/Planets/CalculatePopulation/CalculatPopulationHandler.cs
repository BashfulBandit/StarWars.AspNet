
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Planets;

internal class CalculatPopulationHandler
    : IQueryHandler<CalculatePopulation, CalculatePopulationResult>
{
    private readonly IPlanetsStore _planetStore;

    public CalculatPopulationHandler(IPlanetsStore planetStore)
    {
        this._planetStore = planetStore;
    }

    public async Task<CalculatePopulationResult> HandleAsync(CalculatePopulation query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            // Using a `ulong` here because the population can't be negative, but
            // the population of the universe is large.
            var population = ulong.MinValue;
            var page = (IPage<Planet>)new Page<Planet>();
            var pageNumber = 0;
            do
            {
                page = await this._planetStore.ListAsync(new()
                {
                    Page = ++pageNumber
                }, cancellation);

                foreach (var planet in page.Items)
                {
                    if (planet.Population.HasValue)
                    {
                        population += planet.Population.Value;
                    }
                }
            } while (page.HasNext);

            return CalculatePopulationResult.Success(population);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return CalculatePopulationResult.Failure(CalculatePopulationException.Fault("Failed to calculation the population.", ex));
        }
    }
}

