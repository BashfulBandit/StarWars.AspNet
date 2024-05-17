using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;
using StarWars.AspNet.SWAPI.Clients.Interfaces;

namespace StarWars.AspNet.SWAPI.Tests.Clients;

[Collection(nameof(SWAPICollection))]
public class DiscoveryAsyncTests
{
    private readonly SWAPIFixture _fixture;

    public DiscoveryAsyncTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task DiscoveryAsync_WhenRequestIsMade_ItShouldReturnAResponseWithData()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        var response = await client.DiscoveryAsync();

        Assert.NotNull(response);
        Assert.NotNull(response.People);
        Assert.NotNull(response.Planets);
        Assert.NotNull(response.Films);
        Assert.NotNull(response.Species);
        Assert.NotNull(response.Vehicles);
        Assert.NotNull(response.Starships);
    }
}
