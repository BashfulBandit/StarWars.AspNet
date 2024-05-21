using SWApiClient.Interfaces;
using SWApiClient.Models;
using SWApiClient.Responses.Starships;

namespace StarWars.AspNet.SWAPI.Extensions;

/// <summary>
/// Extension methods for an <see cref="IStarshipsClient"/>.
/// </summary>
internal static class IStarshipsClientExtensions
{
    /// <summary>
    /// Extension method to handle retrieving all of the <see cref="Clients.Models.Starship"/>.
    /// </summary>
    /// <param name="client">The instance of the <see cref="IStarshipsClient"/>.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>An asynchronous task representing the operation of retrieving all the <see cref="Clients.Models.Starship"/></returns>
    public static async Task<IEnumerable<Starship>> GetAllAsync(this IStarshipsClient client,
        CancellationToken cancellation = default)
    {
        var starships = new List<Starship>();

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
