using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Client.Exceptions;
using StarWars.AspNet.Client;
using StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.Integration.Tests.Clients.People.Starships;

[Collection(nameof(StarWarsCollection))]
public class ListAsyncTests
{
    private readonly StarWarsFixture _fixture;

    public ListAsyncTests(StarWarsFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task ListAsync_WhenGivenInvalidPersonId_ItShouldReturnANotFoundException()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        await Assert.ThrowsAsync<StarWarsClientNotFoundException>(async () => await client.People.Starships.ListAsync(new()
        {
            CharacterId = "NotAValidCharacterId"
        }));
    }

    [Fact]
    public async Task ListAsync_WhenGivenValidPersonIdWithNoQueryParameters_ItShouldReturnAResponse()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        var response = await client.People.Starships.ListAsync(new()
        {
            CharacterId = "1"
        });

        Assert.NotNull(response);
        Assert.NotNull(response.Pagination);
        Assert.NotNull(response.Starships);
    }
}
