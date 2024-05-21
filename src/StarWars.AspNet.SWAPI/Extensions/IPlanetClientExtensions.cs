using SWApiClient.Interfaces;
using SWApiClient.Models;
using SWApiClient.Responses.Planets;

namespace StarWars.AspNet.SWAPI.Extensions;

/// <summary>
/// Extension methods for an <see cref="IPlanetsClient"/>.
/// </summary>
internal static class IPlanetClientExtensions
{
    /// <summary>
    /// Extension method to handle retrieving all of the <see cref="Clients.Models.Planet"/>.
    /// </summary>
    /// <param name="client">The instance of the <see cref="IPlanetsClient"/>.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>An asynchronous task representing the operation of retrieving all the <see cref="Clients.Models.Planet"/></returns>
    public static async Task<IEnumerable<Planet>> GetAllAsync(this IPlanetsClient client,
        CancellationToken cancellation = default)
    {
        var planets = new List<Planet>();

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
