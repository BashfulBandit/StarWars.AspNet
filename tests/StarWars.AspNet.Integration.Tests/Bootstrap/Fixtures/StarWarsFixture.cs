using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Integration.Tests.Bootstrap.Containers;

namespace StarWars.AspNet.Integration.Tests.Bootstrap.Fixtures;

public class StarWarsFixture
    : IDisposable
{
    private readonly TestContainers _containers = new();

    public IServiceProvider ServiceProvider { get; }

    public StarWarsFixture()
    {
        this._containers.InitializeAsync().Wait();
        this.ServiceProvider = new ServiceCollection()
            .AddStarWarsClient(o =>
            {
                o.BaseUrl = StarWarsApiConfigurations.BaseUrlForHostCommunication;
            })
            .BuildServiceProvider();
    }

    #region IDisposable

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (this.disposedValue) return;

        if (disposing)
        {
            this._containers.DisposeAsync().Wait();
        }

        this.disposedValue = true;
    }

    public void Dispose()
    {
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion IDisposable
}

[CollectionDefinition(nameof(StarWarsCollection))]
public class StarWarsCollection
    : ICollectionFixture<StarWarsFixture>
{ }
