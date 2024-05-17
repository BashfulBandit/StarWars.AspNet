using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class FilmsStoreTests
{
    private readonly SWAPIFixture _fixture;

    public FilmsStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidFilmId_ItShouldReturnAFilm()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IFilmsStore>();

        var filmId = FilmId.From("1");
        var film = await store.FetchAsync(filmId);

        Assert.NotNull(film);
        Assert.Equal(filmId, film.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidFilmId_ItShouldReturnAFilm()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IFilmsStore>();

        var filmId = FilmId.From("NotAValidFilmId");
        var film = await store.FetchAsync(filmId);

        Assert.Null(film);
    }
}
