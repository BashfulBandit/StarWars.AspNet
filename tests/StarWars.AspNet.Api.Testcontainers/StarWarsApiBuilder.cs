using Docker.DotNet.Models;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;

namespace StarWars.AspNet.Api.Testcontainers;

/// <summary>
/// Initializes a new instance of the <see cref="StarWarsApiBuilder" /> class.
/// </summary>
/// <param name="configuration">The Docker resource configuration.</param>
public class StarWarsApiBuilder
    : ContainerBuilder<StarWarsApiBuilder, StarWarsApiContainer, StarWarsApiConfiguration>
{
    public const string Image = "localhost/starwars.aspnet.api:0.1.0";

    public const ushort HttpPort = 8080;
    public const ushort HttpsPort = 8081;

    /// <summary>
    /// Initializes a new instance of the <see cref="StarWarsApiBuilder" /> class.
    /// </summary>
    public StarWarsApiBuilder()
        : this(new())
    {
        this.DockerResourceConfiguration = this.Init().DockerResourceConfiguration;
    }

    public StarWarsApiBuilder(StarWarsApiConfiguration configuration)
        : base(configuration)
    {
        this.DockerResourceConfiguration = configuration;
    }

    /// <inheritdoc />
    protected override StarWarsApiConfiguration DockerResourceConfiguration { get; }

    /// <inheritdoc />
    protected override StarWarsApiBuilder Init()
    {
        return base.Init()
            .WithImage(Image)
            .WithPortBinding(HttpPort, true)
            .WithPortBinding(HttpsPort, true);
    }

    /// <inheritdoc />
    public override StarWarsApiContainer Build()
    {
        this.Validate();

        return new(this.DockerResourceConfiguration);
    }

    public StarWarsApiBuilder WithStoresConfigurations(StoresConfigurations? stores)
    {
        var builder = this;

        if (stores?.SWAPI is not null)
        {
            builder = builder.Merge(builder.DockerResourceConfiguration, new())
                .WithSWAPIConfigurations(stores.SWAPI);
        }

        return builder;

    }

    public StarWarsApiBuilder WithSWAPIConfigurations(SWAPIConfiguration? swapi)
    {
        var builder = this;

        if (swapi?.BaseUrl is not null)
        {
            builder = builder.Merge(builder.DockerResourceConfiguration, new())
                .WithEnvironment("STORES__SWAPI__BASEURL", swapi.BaseUrl);
        }

        return builder;
    }

    /// <inheritdoc />
    protected override StarWarsApiBuilder Clone(IContainerConfiguration resourceConfiguration)
        => this.Merge(this.DockerResourceConfiguration, new(resourceConfiguration));

    /// <inheritdoc />
    protected override StarWarsApiBuilder Clone(IResourceConfiguration<CreateContainerParameters> resourceConfiguration)
        => this.Merge(this.DockerResourceConfiguration, new(resourceConfiguration));

    /// <inheritdoc />
    protected override StarWarsApiBuilder Merge(StarWarsApiConfiguration oldValue,
        StarWarsApiConfiguration newValue)
        => new(new(oldValue, newValue));
}
