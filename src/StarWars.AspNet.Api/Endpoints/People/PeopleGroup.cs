namespace StarWars.AspNet.Api.Endpoints.People;

internal class PeopleGroup
    : FastEndpoints.Group
{
    public PeopleGroup()
    {
        this.Configure("people", _ => { });
    }
}
