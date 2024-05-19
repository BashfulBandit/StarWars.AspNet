using StarWars.AspNet.Client;
using StarWars.AspNet.Client.Http;

namespace Microsoft.Extensions.DependencyInjection;

public static class ClientServiceCollectionExtensions
{
    /// <summary>
    /// Extension method for adding the <see cref="StarWarsClient"/> as a
    /// <see cref="IStarWarsClient"/> to the provided <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <param name="configureOptions">Action to configure the <see cref="StarWarsClientOptions"/> to be used.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the dependencies added.</returns>
    public static IServiceCollection AddStarWarsClient(this IServiceCollection services,
        Action<StarWarsClientOptions>? configureOptions = null)
    {
        var options = new StarWarsClientOptions();
        services.AddSingleton(options);
        configureOptions?.Invoke(options);

        services.AddTransient<IStarWarsClient, StarWarsClient>();

        return services;
    }
}
