using Microsoft.Extensions.DependencyInjection;

namespace StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

public class SWAPIFixture
{
    public IServiceProvider ServiceProvider { get; }

    public SWAPIFixture()
    {
        this.ServiceProvider = new ServiceCollection()
            .AddStarWarsBuilder()
            .AddSWAPIStores(o =>
            {
                o.BaseUrl = "https://swapi.dev";
            })
            .Services
            .AddLogging()
            .BuildServiceProvider();
    }
}

[CollectionDefinition(nameof(SWAPICollection))]
public class SWAPICollection
    : ICollectionFixture<SWAPIFixture>
{ }
