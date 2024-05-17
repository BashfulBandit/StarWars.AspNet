using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class StarshipsStoreTests
{
    private readonly SWAPIFixture _fixture;

    public StarshipsStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidStarshipId_ItShouldReturnAStarship()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IStarshipsStore>();

        var startshipId = StarshipId.From("2");
        var starship = await store.FetchAsync(startshipId);

        Assert.NotNull(starship);
        Assert.Equal(startshipId, starship.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidStarshipId_ItShouldReturnNull()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IStarshipsStore>();

        var starshipId = StarshipId.From("NotAValidStarshipId");
        var starship = await store.FetchAsync(starshipId);

        Assert.Null(starship);
    }
}
