using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;

namespace StarWars.AspNet.SWAPI.Tests.Clients.Starships;

[Collection(nameof(SWAPICollection))]
public class RetrieveAsyncTests
{
    private readonly SWAPIFixture _fixture;

    public RetrieveAsyncTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAValidStarshipId_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        var response = await client.Starships.RetrieveAsync(new()
        {
            StarshipId = "2"
        });

        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAInvalidStarshipId_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        await Assert.ThrowsAsync<SWAPIClientNotFoundException>(async () => await client.Starships.RetrieveAsync(new()
        {
            StarshipId = "NotAValidStarshipId"
        }));
    }
}
