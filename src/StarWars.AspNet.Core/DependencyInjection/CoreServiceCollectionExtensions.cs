using System.Reflection;
using StarWars.AspNet.Core.Commands;
using StarWars.AspNet.Core.DependencyInjection;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Stores;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for a <see cref="IServiceCollection"/> and <see cref="IStarWarsBuilder"/>.
/// </summary>
public static class CoreServiceCollectionExtensions
{
    /// <summary>
    /// Extension method to create an instance of an <see cref="IStarWarsBuilder"/> from
    /// an <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <returns></returns>
    public static IStarWarsBuilder AddStarWarsBuilder(this IServiceCollection services)
        => new StarWarsBuilder(services);

    /// <summary>
    /// Extension method to create an <see cref="IStarWarsBuilder"/> and add all
    /// the default <see cref="StarWars.AspNet.Core"/> dependencies to the
    /// provided <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IStarWarsBuilder"/>.</returns>
    public static IStarWarsBuilder AddStarWarsCore(this IServiceCollection services)
        => services.AddStarWarsBuilder()
            .AddStarWarsCore();

    /// <summary>
    /// Extension method to add all the default <see cref="StarWars.AspNet.Core"/>
    /// dependencies to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <returns>The <see cref="IStarWarsBuilder"/>.</returns>
    internal static IStarWarsBuilder AddStarWarsCore(this IStarWarsBuilder builder)
    {
        // Add all CQRS Handlers...
        builder.AddCQRSHandlers(typeof(IStarWarsBuilder).Assembly);

        // Add default no-op stores...
        builder.AddEpisodesStore<NoOpEpisodesStore>();
        builder.AddCharacterStore<NoOpCharactersStore>();
        builder.AddPlanetsStore<NoOpPlanetsStore>();
        builder.AddSpeciesStore<NoOpSpeciesStore>();
        builder.AddStarshipsStore<NoOpStarshipsStore>();
        builder.AddVehiclesStore<NoOpVehiclesStore>();

        return builder;
    }

    /// <summary>
    /// Extension method to add all of the <see cref="ICommandHandler{TCommand,TCommandResult}"/>
    /// and <see cref="IQueryHandler{TQuery, TQueryResult}{TCommand,TCommandResult}"/>
    /// from the provided <see cref="Assembly"/> to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <param name="assembly">The <see cref="Assembly"/>.</param>
    /// <returns></returns>
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
                i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)
                || i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));

            if (serviceType is null) continue;

            builder.Services.AddTransient(serviceType, implementationType);
        }

        return builder;
    }

    /// <summary>
    /// Extension method to add a <typeparamref name="TStore"/> implementation
    /// of an <see cref="IEpisodesStore"/> to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <typeparam name="TStore">The type of the implementation to add.</typeparam>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <returns>
    /// The <see cref="IStarWarsBuilder"/> with the <typeparamref name="TStore"/>
    /// added to it as a <see cref="IEpisodesStore"/>.
    /// </returns>
    public static IStarWarsBuilder AddEpisodesStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IEpisodesStore
    {
        builder.Services.AddTransient<IEpisodesStore, TStore>();

        return builder;
    }

    /// <summary>
    /// Extension method to add a <typeparamref name="TStore"/> implementation
    /// of an <see cref="ICharactersStore"/> to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <typeparam name="TStore">The type of the implementation to add.</typeparam>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <returns>
    /// The <see cref="IStarWarsBuilder"/> with the <typeparamref name="TStore"/>
    /// added to it as a <see cref="ICharactersStore"/>.
    /// </returns>
    public static IStarWarsBuilder AddCharacterStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, ICharactersStore
    {
        builder.Services.AddTransient<ICharactersStore, TStore>();

        return builder;
    }

    /// <summary>
    /// Extension method to add a <typeparamref name="TStore"/> implementation
    /// of an <see cref="IPlanetsStore"/> to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <typeparam name="TStore">The type of the implementation to add.</typeparam>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <returns>
    /// The <see cref="IStarWarsBuilder"/> with the <typeparamref name="TStore"/>
    /// added to it as a <see cref="IPlanetsStore"/>.
    /// </returns>
    public static IStarWarsBuilder AddPlanetsStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IPlanetsStore
    {
        builder.Services.AddTransient<IPlanetsStore, TStore>();

        return builder;
    }

    /// <summary>
    /// Extension method to add a <typeparamref name="TStore"/> implementation
    /// of an <see cref="ISpeciesStore"/> to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <typeparam name="TStore">The type of the implementation to add.</typeparam>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <returns>
    /// The <see cref="IStarWarsBuilder"/> with the <typeparamref name="TStore"/>
    /// added to it as a <see cref="ISpeciesStore"/>.
    /// </returns>
    public static IStarWarsBuilder AddSpeciesStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, ISpeciesStore
    {
        builder.Services.AddTransient<ISpeciesStore, TStore>();

        return builder;
    }

    /// <summary>
    /// Extension method to add a <typeparamref name="TStore"/> implementation
    /// of an <see cref="IStarshipsStore"/> to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <typeparam name="TStore">The type of the implementation to add.</typeparam>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <returns>
    /// The <see cref="IStarWarsBuilder"/> with the <typeparamref name="TStore"/>
    /// added to it as a <see cref="IStarshipsStore"/>.
    /// </returns>
    public static IStarWarsBuilder AddStarshipsStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IStarshipsStore
    {
        builder.Services.AddTransient<IStarshipsStore, TStore>();

        return builder;
    }

    /// <summary>
    /// Extension method to add a <typeparamref name="TStore"/> implementation
    /// of an <see cref="IVehiclesStore"/> to the <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <typeparam name="TStore">The type of the implementation to add.</typeparam>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <returns>
    /// The <see cref="IStarWarsBuilder"/> with the <typeparamref name="TStore"/>
    /// added to it as a <see cref="IVehiclesStore"/>.
    /// </returns>
    public static IStarWarsBuilder AddVehiclesStore<TStore>(this IStarWarsBuilder builder)
        where TStore : class, IVehiclesStore
    {
        builder.Services.AddTransient<IVehiclesStore, TStore>();

        return builder;
    }
}
