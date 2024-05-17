using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Client;
using StarWars.AspNet.Client.Exceptions;
using StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.Integration.Tests.Clients.Episodes.Species;

[Collection(nameof(StarWarsCollection))]
public class ListAsyncTests
{
    private readonly StarWarsFixture _fixture;

    public ListAsyncTests(StarWarsFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task ListAsync_WhenGivenInvalidEpisodeId_ItShouldReturnANotFoundException()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        await Assert.ThrowsAsync<StarWarsClientNotFoundException>(async () => await client.Episodes.Species.ListAsync(new()
        {
            EpisodeId = "NotAValidEpisodeId"
        }));
    }

    [Fact]
    public async Task ListAsync_WhenGivenValidEpisodeIdWithNoQueryParameters_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        var response = await client.Episodes.Species.ListAsync(new()
        {
            EpisodeId = "1"
        });

        Assert.NotNull(response);
        Assert.NotNull(response.Pagination);
        Assert.NotNull(response.Species);
    }
}
