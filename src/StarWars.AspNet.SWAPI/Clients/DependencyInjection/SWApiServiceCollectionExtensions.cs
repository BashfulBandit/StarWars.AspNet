using StarWars.AspNet.SWAPI.Clients.Impl;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Options;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for an <see cref="IServiceCollection"/> to handle
/// adding the <see cref="ISWAPIClient"/>.
/// </summary>
public static class SWAPIClientServiceCollectionExtensions
{
    /// <summary>
    /// Adds a <see cref="ISWAPIClient"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <param name="configureOptions">Options action to configure the <see cref="SWAPIClientOptions"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> after the <see cref="ISWAPIClient"/> is added.</returns>
    public static IServiceCollection AddSWAPIClient(this IServiceCollection services,
        Action<SWAPIClientOptions>? configureOptions = null)
    {
        var options = new SWAPIClientOptions();
        services.AddSingleton(options);
        configureOptions?.Invoke(options);

        services.AddSingleton<ISWAPIClient, SWAPIClient>();

        return services;
    }
}
