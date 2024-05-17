using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Responses.Species;

namespace StarWars.AspNet.SWAPI.Extensions;

internal static class ISpeciesClientExtensions
{
    public static async Task<IEnumerable<Clients.Models.Species>> GetAllAsync(this ISpeciesClient client,
        CancellationToken cancellation = default)
    {
        var species = new List<Clients.Models.Species>();
        var page = 0;
        ListSpeciesResponse? response;
        do
        {
            response = await client.ListAsync(new()
            {
                Page = ++page
            }, cancellation);

            species.AddRange(response.Results);
        } while (response.Next is not null);

        return species;
    }
}
