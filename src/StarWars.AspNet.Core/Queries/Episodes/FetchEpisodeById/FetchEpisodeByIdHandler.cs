
using StarWars.AspNet.Core.Stores;

namespace StarWars.AspNet.Core.Queries.Episodes;

/// <summary>
/// Handler to process a <see cref="FetchEpisodeById"/> query and return a
/// <see cref="FetchEpisodeByIdResult"/>.
/// </summary>
internal class FetchEpisodeByIdHandler
    : IQueryHandler<FetchEpisodeById, FetchEpisodeByIdResult>
{
    private readonly IEpisodesStore _episodesStore;

    public FetchEpisodeByIdHandler(IEpisodesStore episodesStore)
    {
        this._episodesStore = episodesStore;
    }

    public async Task<FetchEpisodeByIdResult> HandleAsync(FetchEpisodeById query, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var character = await this._episodesStore.FetchAsync(query.EpisodeId, cancellation);
            if (character is null)
            {
                return FetchEpisodeByIdResult.NotFound(query.EpisodeId);
            }
            return FetchEpisodeByIdResult.Success(character);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return FetchEpisodeByIdResult.Failure(FetchEpisodeByIdException.Fault($"Failed to fetch a episode by id `{query.EpisodeId.Value}`.", ex));
        }
    }
}
