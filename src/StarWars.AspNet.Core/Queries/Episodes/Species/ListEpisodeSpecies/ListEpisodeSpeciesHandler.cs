using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Episodes.Species;

internal class ListEpisodeSpeciesHandler
    : IQueryHandler<ListEpisodeSpecies, ListEpisodeSpeciesResult>
{
    private readonly IEpisodesStore _episodeStore;
    private readonly ISpeciesStore _speciesStore;

    public ListEpisodeSpeciesHandler(IEpisodesStore episodeStore,
        ISpeciesStore speciesStore)
    {
        this._episodeStore = episodeStore;
        this._speciesStore = speciesStore;
    }

    public async Task<ListEpisodeSpeciesResult> HandleAsync(ListEpisodeSpecies query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            await this.ValidateAsync(query, cancellation);
            var page = await this._speciesStore.ListAsync(query.Filter, cancellation);
            return ListEpisodeSpeciesResult.Success(page);
        }
        catch (ListEpisodeSpeciesException ex)
        {
            return ListEpisodeSpeciesResult.Failure(ex);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return ListEpisodeSpeciesResult.Failure(ListEpisodeSpeciesException.Fault("Failed to list species for episode `{episodeId}`.", ex));
        }
    }

    private async Task ValidateAsync(ListEpisodeSpecies query, CancellationToken cancellation = default)
    {
        _ = await this._episodeStore.FetchAsync(query.Filter.EpisodeId!.Value, cancellation)
            ?? throw ListEpisodeSpeciesException.EpisodeNotFound(query.Filter.EpisodeId.Value);
    }
}
