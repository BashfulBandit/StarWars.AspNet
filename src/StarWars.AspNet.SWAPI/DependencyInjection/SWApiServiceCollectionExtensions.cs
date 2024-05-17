using StarWars.AspNet.Core.DependencyInjection;
using StarWars.AspNet.SWAPI.Clients.Options;
using StarWars.AspNet.SWAPI.Stores;

namespace Microsoft.Extensions.DependencyInjection;

public static class SWAPIServiceCollectionExtensions
{
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
        builder.AddPeopleStore<PeopleStore>();
        builder.AddPlanetsStore<PlanetsStore>();
        builder.AddSpeciesStore<SpeciesStore>();
        builder.AddStarshipsStore<StarshipsStore>();
        builder.AddVehiclesStore<VehiclesStore>();

        return builder;
    }
}
