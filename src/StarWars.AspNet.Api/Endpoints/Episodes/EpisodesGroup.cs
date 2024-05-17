namespace StarWars.AspNet.Api.Endpoints.Episodes;

internal class EpisodesGroup
    : FastEndpoints.Group
{
    public EpisodesGroup()
    {
        this.Configure("episodes", _ => { });
    }
}
