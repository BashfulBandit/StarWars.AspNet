using Microsoft.Extensions.DependencyInjection;

namespace StarWars.AspNet.Core.DependencyInjection;

/// <summary>
/// Interface to be used for building the dependencies for <see cref="AspNet.Api"/>.
/// </summary>
public interface IStarWarsBuilder
{
    /// <summary>
    /// Gets the services.
    /// </summary>
    /// <value>
    /// The services.
    /// </value>
    public IServiceCollection Services { get; }
}

/// <summary>
/// <see cref="StarWars.AspNet"/> helper class for DI configuration.
/// </summary>
internal class StarWarsBuilder
        : IStarWarsBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IStarWarsBuilder"/> class.
    /// </summary>
    public StarWarsBuilder(IServiceCollection services)
    {
        this.Services = services;
    }

    /// <inheritdoc/>
    public IServiceCollection Services { get; init; }
}
