namespace StarWars.AspNet.Api.Endpoints.People.Starships;

internal class CharacterStarshipsGroup
    : FastEndpoints.SubGroup<CharactersGroup>
{
    public CharacterStarshipsGroup()
    {
        this.Configure("{characterId}/starships", _ => { });
    }
}
