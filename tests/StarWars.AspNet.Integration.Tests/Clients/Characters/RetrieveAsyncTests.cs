using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Client;
using StarWars.AspNet.Client.Exceptions;
using StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.Integration.Tests.Clients.Characters;

[Collection(nameof(StarWarsCollection))]
public class RetrieveAsyncTests
{
    private readonly StarWarsFixture _fixture;

    public RetrieveAsyncTests(StarWarsFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAValidCharacterId_ItShouldReturnTheCharacter()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        var response = await client.Characters.RetrieveAsync(new()
        {
            CharacterId = "1"
        });

        Assert.NotNull(response);
        Assert.NotNull(response.Character);
        Assert.NotNull(response.Character.Id);
    }

    [Fact]
    public async Task RetrieveAsync_WhenGivenAInvalidCharacterId_ItShouldReturnTheCharacter()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        await Assert.ThrowsAsync<StarWarsClientNotFoundException>(async () => await client.Characters.RetrieveAsync(new()
        {
            CharacterId = "SomeInvalidCharacterId"
        }));
    }
}
