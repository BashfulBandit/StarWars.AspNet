using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Client;
using StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.Integration.Tests.Clients;

[Collection(nameof(StarWarsCollection))]
public class GetPopulationAsyncTests
{
    private readonly StarWarsFixture _fixture;

    public GetPopulationAsyncTests(StarWarsFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task GetPopulationAsync()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        var response = await client.GetPopulationAsync();

        Assert.NotNull(response);
    }
}
