using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Episodes;

internal class ListEpisodesHandler
    : IQueryHandler<ListEpisodes, ListEpisodesResult>
{
    private readonly IEpisodesStore _episodesStore;

    public ListEpisodesHandler(IEpisodesStore episodesStore)
    {
        this._episodesStore = episodesStore;
    }

    public async Task<ListEpisodesResult> HandleAsync(ListEpisodes query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var page = await this._episodesStore.ListAsync(query.Filter, cancellation);
            return ListEpisodesResult.Success(page);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return ListEpisodesResult.Failure(ListEpisodesException.Fault("Failed to list episodes.", ex));
        }
    }
}
