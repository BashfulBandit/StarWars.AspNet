using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Client;
using StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.Integration.Tests.Clients.Characters;

[Collection(nameof(StarWarsCollection))]
public class ListAsyncTests
{
    private readonly StarWarsFixture _fixture;

    public ListAsyncTests(StarWarsFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task ListAsync_WhenGivenDefaultRequest_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        var response = await client.Characters.ListAsync();

        Assert.NotNull(response);
        Assert.NotNull(response.Pagination);
        Assert.NotNull(response.Characters);
    }
}
