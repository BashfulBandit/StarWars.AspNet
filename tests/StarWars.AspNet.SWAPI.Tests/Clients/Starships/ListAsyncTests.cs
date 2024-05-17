using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;
using StarWars.AspNet.SWAPI.Clients.Interfaces;

namespace StarWars.AspNet.SWAPI.Tests.Clients.Starships;

[Collection(nameof(SWAPICollection))]
public class ListAsyncTests
{
    private readonly SWAPIFixture _fixture;

    public ListAsyncTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task ListAsync_NoRequestParameterProvided_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        var response = await client.Starships.ListAsync();

        Assert.NotNull(response);
        Assert.NotNull(response.Next);
        Assert.Null(response.Previous);
        Assert.NotNull(response.Results);
    }
}
