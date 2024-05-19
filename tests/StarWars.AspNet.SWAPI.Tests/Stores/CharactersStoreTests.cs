using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class CharactersStoreTests
{
    private readonly SWAPIFixture _fixture;

    public CharactersStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidCharacterId_ItShouldReturnACharacter()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<ICharactersStore>();

        var characterId = CharacterId.From("1");
        var character = await store.FetchAsync(characterId);

        Assert.NotNull(character);
        Assert.Equal(characterId, character.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidCharacterId_ItShouldReturnNull()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<ICharactersStore>();

        var personId = CharacterId.From("NotAValidCharacterId");
        var person = await store.FetchAsync(personId);

        Assert.Null(person);
    }
}
