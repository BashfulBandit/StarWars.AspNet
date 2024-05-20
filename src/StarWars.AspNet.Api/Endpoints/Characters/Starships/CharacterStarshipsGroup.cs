namespace StarWars.AspNet.Api.Endpoints.Characters.Starships;

internal class CharacterStarshipsGroup
    : FastEndpoints.SubGroup<CharactersGroup>
{
    public CharacterStarshipsGroup()
    {
        this.Configure("{characterId}/starships", _ => { });
    }
}
