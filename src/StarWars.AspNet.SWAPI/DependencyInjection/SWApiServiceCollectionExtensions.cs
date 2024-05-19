using StarWars.AspNet.Core.DependencyInjection;
using StarWars.AspNet.SWAPI.Stores;
using SWApiClient.Options;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for an <see cref="IStarWarsBuilder"/> to handle add dependencies
/// to the provided <see cref="IStarWarsBuilder"/> for this project.
/// </summary>
public static class SWAPIServiceCollectionExtensions
{
    /// <summary>
    /// Adds the depedencies for this project to the provided <see cref="IStarWarsBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IStarWarsBuilder"/>.</param>
    /// <param name="configureOptions">
    /// Optional options action to configure the internal options.
    /// </param>
    /// <returns>The <see cref="IStarWarsBuilder"/> after the dependencies are added.</returns>
    public static IStarWarsBuilder AddSWAPIStores(this IStarWarsBuilder builder,
        Action<SWAPIClientOptions>? configureOptions = null)
    {
        var options = new SWAPIClientOptions();
        builder.Services.AddSingleton(options);
        configureOptions?.Invoke(options);

        builder.Services.AddSWAPIClient(o =>
        {
            o.BaseUrl = options.BaseUrl;
        });

        builder.AddEpisodesStore<EpisodesStore>();
        builder.AddCharacterStore<CharactersStore>();
        builder.AddPlanetsStore<PlanetsStore>();
        builder.AddSpeciesStore<SpeciesStore>();
        builder.AddStarshipsStore<StarshipsStore>();
        builder.AddVehiclesStore<VehiclesStore>();

        return builder;
    }
}
