namespace StarWars.AspNet.Api.Endpoints.Episodes.Species;

internal class SpeciesGroup
    : FastEndpoints.SubGroup<EpisodesGroup>
{
    public SpeciesGroup()
    {
        this.Configure("{episodeId}/species", _ => { });
    }
}
