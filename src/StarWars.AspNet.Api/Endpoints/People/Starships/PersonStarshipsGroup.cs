namespace StarWars.AspNet.Api.Endpoints.People.Starships;

internal class PersonStarshipsGroup
    : FastEndpoints.SubGroup<PeopleGroup>
{
    public PersonStarshipsGroup()
    {
        this.Configure("{personId}/starships", _ => { });
    }
}
