using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class PlanetStoreTests
{
    private readonly SWAPIFixture _fixture;

    public PlanetStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidPlanetId_ItShouldReturnAPlanet()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IPlanetsStore>();

        var planetId = PlanetId.From("1");
        var planet = await store.FetchAsync(planetId);

        Assert.NotNull(planet);
        Assert.Equal(planetId, planet.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidPlanetId_ItShouldReturnNull()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IPlanetsStore>();

        var planetId = PlanetId.From("NotAValidPlanetId");
        var planet = await store.FetchAsync(planetId);

        Assert.Null(planet);
    }
}
