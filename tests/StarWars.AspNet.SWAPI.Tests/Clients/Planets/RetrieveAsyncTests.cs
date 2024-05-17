using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;
using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;

namespace StarWars.AspNet.SWAPI.Tests.Clients.Planets;

[Collection(nameof(SWAPICollection))]
public class RetrieveAsyncTests
{
    private readonly SWAPIFixture _fixture;

    public RetrieveAsyncTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAValidPlanetId_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        var response = await client.Planets.RetrieveAsync(new()
        {
            PlanetId = "1"
        });

        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAInvalidPlanetId_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        await Assert.ThrowsAsync<SWAPIClientNotFoundException>(async () => await client.Planets.RetrieveAsync(new()
        {
            PlanetId = "NotAValidPlanetId"
        }));
    }
}
