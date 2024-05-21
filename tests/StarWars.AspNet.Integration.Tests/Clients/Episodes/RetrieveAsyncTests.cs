using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Client.Exceptions;
using StarWars.AspNet.Client;
using StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.Integration.Tests.Clients.Episodes;

[Collection(nameof(StarWarsCollection))]
public class RetrieveAsyncTests
{
    private readonly StarWarsFixture _fixture;

    public RetrieveAsyncTests(StarWarsFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAValidEpisodeId_ItShouldReturnTheEpisode()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        var response = await client.Episodes.RetrieveAsync(new()
        {
            EpisodeId = "1"
        });

        Assert.NotNull(response);
        Assert.NotNull(response.Episode);
        Assert.NotNull(response.Episode.Id);
        Assert.Equal("1", response.Episode.Id);
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAInvalidEpisodeId_ItShouldthrowAnException()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        await Assert.ThrowsAsync<StarWarsClientNotFoundException>(async () => await client.Episodes.RetrieveAsync(new()
        {
            EpisodeId = "SomeInvalidEpisodeId"
        }));
    }
}
