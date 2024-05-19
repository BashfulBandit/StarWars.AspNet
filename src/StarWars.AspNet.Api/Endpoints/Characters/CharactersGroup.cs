namespace StarWars.AspNet.Api.Endpoints.People;

internal class CharactersGroup
    : FastEndpoints.Group
{
    public CharactersGroup()
    {
        this.Configure("characters", _ => { });
    }
}
