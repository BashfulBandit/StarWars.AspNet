using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class EpisodesStoreTests
{
    private readonly SWAPIFixture _fixture;

    public EpisodesStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidEpisodeId_ItShouldReturnAnEpisode()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IEpisodesStore>();

        var episodeId = EpisodeId.From("1");
        var episode = await store.FetchAsync(episodeId);

        Assert.NotNull(episode);
        Assert.Equal(episodeId, episode.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidEpisodeId_ItShouldReturnNull()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IEpisodesStore>();

        var episodeId = EpisodeId.From("NotAValidEpisodeId");
        var episode = await store.FetchAsync(episodeId);

        Assert.Null(episode);
    }
}
