using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Commands.Planets;

/// <summary>
/// Handler to process a <see cref="CalculatePopulation"/> command and return a
/// <see cref="CalculatePopulationResult"/>.
/// </summary>
internal class CalculatePopulationHandler
    : ICommandHandler<CalculatePopulation, CalculatePopulationResult>
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
            var result = CalculatePopulationResult.Success(ulong.MinValue);
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
                    result.Population += planet.Population.Value;
                }
            }
            return result;
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

