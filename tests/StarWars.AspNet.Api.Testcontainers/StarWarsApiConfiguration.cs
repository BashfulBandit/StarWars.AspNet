using Docker.DotNet.Models;
using DotNet.Testcontainers.Configurations;

namespace StarWars.AspNet.Api.Testcontainers;

public class StarWarsApiConfiguration
    : ContainerConfiguration
{
    /// <inheritdoc />
    public StarWarsApiConfiguration(StoresConfigurations? stores = null)
        : base()
    {
        this.Stores = stores;
    }

    /// <inheritdoc />
    public StarWarsApiConfiguration(IResourceConfiguration<CreateContainerParameters> configuration)
        : base(configuration)
    { }

    /// <inheritdoc />
    public StarWarsApiConfiguration(IContainerConfiguration configuration)
        : base(configuration)
    { }

    /// <inheritdoc />
    public StarWarsApiConfiguration(IContainerConfiguration oldValue, IContainerConfiguration newValue)
        : base(oldValue, newValue)
    { }

    public StoresConfigurations? Stores { get; init; } = null;
}

public class StoresConfigurations
{
    public SWAPIConfiguration? SWAPI { get; set; } = null;
}

public class SWAPIConfiguration
{
    public string? BaseUrl { get; set; } = null;
}
