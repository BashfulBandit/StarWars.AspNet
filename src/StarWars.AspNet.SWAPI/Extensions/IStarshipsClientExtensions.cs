using SWApiClient.Interfaces;
using SWApiClient.Models;

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

        // Get first page, so we can calculate how many other requests to make.
        var firstPage = await client.ListAsync(new()
        {
            Page = 1
        }, cancellation);

        // Create the Tasks for each page request.
        var pages = await Task.WhenAll(
            Enumerable.Range(2, (int) Math.Ceiling((double) (firstPage.Count - firstPage.Results.Count()) / firstPage.Results.Count()))
            .Select(p => client.ListAsync(new()
            {
                Page = p
            }, cancellation)));

        // Add first page results and then the following page results.
        // May need to consider possible duplicates, but that seems unlikely
        // with the data coming from the SW API.
        starships.AddRange(firstPage.Results.Union(pages.SelectMany(p => p.Results)));

        return starships;
    }
}
