using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Client;
using StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.Integration.Tests.Clients;

[Collection(nameof(StarWarsCollection))]
public class HealthCheckAsyncTests
{
    private readonly StarWarsFixture _fixture;

    public HealthCheckAsyncTests(StarWarsFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task HealthCheckAsync()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var client = scope.ServiceProvider.GetRequiredService<IStarWarsClient>();

        await client.HealthCheckAsync();
    }
}
