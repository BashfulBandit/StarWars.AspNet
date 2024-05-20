namespace StarWars.AspNet.Api.Endpoints.Characters;

internal class CharactersGroup
    : FastEndpoints.Group
{
    public CharactersGroup()
    {
        this.Configure("characters", _ => { });
    }
}
