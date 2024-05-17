using StarWars.AspNet.Client;
using StarWars.AspNet.Client.Http;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
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
