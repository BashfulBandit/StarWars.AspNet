namespace StarWars.AspNet.Api.Endpoints.Episodes.Species;

internal class EpisodeSpeciesGroup
    : FastEndpoints.SubGroup<EpisodesGroup>
{
    public EpisodeSpeciesGroup()
    {
        this.Configure("{episodeId}/species", _ => { });
    }
}
