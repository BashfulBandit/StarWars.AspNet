using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Networks;
using StarWars.AspNet.Api.Testcontainers;
using StarWars.AspNet.Integration.Tests.Bootstrap.Images;

namespace StarWars.AspNet.Integration.Tests.Bootstrap.Containers;

internal class TestContainers
    : IAsyncLifetime
{
    private static readonly StarWarsApiImage StarWarsApiImage = new();

    private readonly INetwork _network;
    private readonly StarWarsApiContainer _starWarsApiContainer;

    public TestContainers()
    {
        this._network = new NetworkBuilder()
            .Build();

        this._starWarsApiContainer = new StarWarsApiBuilder()
            .WithImage(StarWarsApiImage)
            .WithNetwork(this._network)
            .WithNetworkAliases(StarWarsApiConfigurations.Hostname)
            .WithPortBinding(StarWarsApiConfigurations.HttpHostPort, StarWarsApiConfigurations.HttpContainerPort)
            .WithPortBinding(StarWarsApiConfigurations.HttpsHostPort, StarWarsApiConfigurations.HttpsContainerPort)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(StarWarsApiConfigurations.HttpContainerPort))
            .WithStoresConfigurations(StarWarsApiConfigurations.Stores)
            .Build();
    }

    public async Task DisposeAsync()
    {
        await this._starWarsApiContainer.DisposeAsync().AsTask();

        await this._network.DisposeAsync().AsTask();
    }

    public async Task InitializeAsync()
    {
        await StarWarsApiImage.InitializeAsync();

        await this._network.CreateAsync();

        await this._starWarsApiContainer.StartAsync();
    }
}
