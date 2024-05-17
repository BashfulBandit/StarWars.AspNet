using System.Reflection;
using StarWars.AspNet.Core.DependencyInjection;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Stores;

namespace Microsoft.Extensions.DependencyInjection;

public static class CoreServiceCollectionExtensions
{
    public static IStarWarsBuilder AddStarWarsBuilder(this IServiceCollection services)
        => new StarWarsBuilder(services);

    public static IStarWarsBuilder AddStarWarsCore(this IServiceCollection services)
        => services.AddStarWarsBuilder()
            .AddStarWarsCore();

    internal static IStarWarsBuilder AddStarWarsCore(this IStarWarsBuilder builder)
    {
        // Add all CQRS Handlers...
        builder.AddCQRSHandlers(typeof(IStarWarsBuilder).Assembly);

        // Add default no-op stores...
        builder.AddEpisodesStore<NoOpEpisodesStore>();
        builder.AddPeopleStore<NoOpPeopleStore>();
        builder.AddPlanetsStore<NoOpPlanetsStore>();
        builder.AddSpeciesStore<NoOpSpeciesStore>();
        builder.AddStarshipsStore<NoOpStarshipsStore>();
        builder.AddVehiclesStore<NoOpVehiclesStore>();

        return builder;
    }

    internal static IStarWarsBuilder AddCQRSHandlers(this IStarWarsBuilder builder,
        Assembly assembly)
    {
        var handlers = assembly.GetTypes()
          .Where(t =>
            t.Name.EndsWith("Handler")
            && t is
            {
                IsClass: true,
                IsAbstract: false
            })
          .ToList();

        foreach (var implementationType in handlers)
        {
            var serviceType = implementationType.GetInterfaces()
              .FirstOrDefault(i =>
                i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));

            if (serviceType is null) continue;

            builder.Services.AddTransient(serviceType, implementationType);
        }

        return builder;
    }

    public static IStarWarsBuilder AddEpisodesStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IEpisodesStore
    {
        builder.Services.AddTransient<IEpisodesStore, TStore>();

        return builder;
    }

    public static IStarWarsBuilder AddPeopleStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IPeopleStore
    {
        builder.Services.AddTransient<IPeopleStore, TStore>();

        return builder;
    }

    public static IStarWarsBuilder AddPlanetsStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IPlanetsStore
    {
        builder.Services.AddTransient<IPlanetsStore, TStore>();

        return builder;
    }

    public static IStarWarsBuilder AddSpeciesStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, ISpeciesStore
    {
        builder.Services.AddTransient<ISpeciesStore, TStore>();

        return builder;
    }

    public static IStarWarsBuilder AddStarshipsStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IStarshipsStore
    {
        builder.Services.AddTransient<IStarshipsStore, TStore>();

        return builder;
    }

    public static IStarWarsBuilder AddVehiclesStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IVehiclesStore
    {
        builder.Services.AddTransient<IVehiclesStore, TStore>();

        return builder;
    }
}
