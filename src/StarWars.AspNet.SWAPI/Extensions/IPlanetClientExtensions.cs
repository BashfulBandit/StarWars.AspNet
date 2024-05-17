using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Responses.Planets;

namespace StarWars.AspNet.SWAPI.Extensions;

internal static class IPlanetClientExtensions
{
    public static async Task<IEnumerable<Clients.Models.Planet>> GetAllAsync(this IPlanetsClient client,
        CancellationToken cancellation = default)
    {
        var planets = new List<Clients.Models.Planet>();
        var page = 0;
        ListPlanetsResponse? response;
        do
        {
            response = await client.ListAsync(new()
            {
                Page = ++page
            }, cancellation);

            planets.AddRange(response.Results);
        } while (response.Next is not null);

        return planets;
    }
}
