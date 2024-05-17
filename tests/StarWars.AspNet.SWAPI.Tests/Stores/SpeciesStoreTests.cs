using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class SpeciesStoreTests
{
    private readonly SWAPIFixture _fixture;

    public SpeciesStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidSpeciesId_ItShouldReturnAFilm()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<ISpeciesStore>();

        var speciesId = SpeciesId.From("1");
        var species = await store.FetchAsync(speciesId);

        Assert.NotNull(species);
        Assert.Equal(speciesId, species.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidSpeciesId_ItShouldReturnAFilm()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<ISpeciesStore>();

        var speciesId = SpeciesId.From("NotAValidSpeciesId");
        var species = await store.FetchAsync(speciesId);

        Assert.Null(species);
    }
}
