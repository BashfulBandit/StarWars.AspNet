using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;
using SWApiClient.Exceptions;
using SWApiClient.Interfaces;

namespace StarWars.AspNet.SWAPI.Tests.Clients.Species;

[Collection(nameof(SWAPICollection))]
public class RetrieveAsyncTests
{
    private readonly SWAPIFixture _fixture;

    public RetrieveAsyncTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAValidSpeciesId_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        var response = await client.Species.RetrieveAsync(new()
        {
            SpeciesId = "1"
        });

        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAInvalidSpeciesId_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<ISWAPIClient>();

        await Assert.ThrowsAsync<SWAPIClientNotFoundException>(async () => await client.Species.RetrieveAsync(new()
        {
            SpeciesId = "NotAValidSpeciesId"
        }));
    }
}
