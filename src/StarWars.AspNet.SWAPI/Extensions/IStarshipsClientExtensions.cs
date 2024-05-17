using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Responses.Starships;

namespace StarWars.AspNet.SWAPI.Extensions;

internal static class IStarshipsClientExtensions
{
    public static async Task<IEnumerable<Clients.Models.Starship>> GetAllAsync(this IStarshipsClient client,
        CancellationToken cancellation = default)
    {
        var starships = new List<Clients.Models.Starship>();
        var page = 0;
        ListStarshipsResponse? response;
        do
        {
            response = await client.ListAsync(new()
            {
                Page = ++page
            }, cancellation);

            starships.AddRange(response.Results);
        } while (response.Next is not null);

        return starships;
    }
}
