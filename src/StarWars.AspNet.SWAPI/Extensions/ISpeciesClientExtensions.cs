using SWApiClient.Interfaces;
using SWApiClient.Models;

namespace StarWars.AspNet.SWAPI.Extensions;

/// <summary>
/// Extension methods for an <see cref="ISpeciesClient"/>.
/// </summary>
internal static class ISpeciesClientExtensions
{
    /// <summary>
    /// Extension method to handle retrieving all of the <see cref="Clients.Models.Species"/>.
    /// </summary>
    /// <param name="client">The instance of the <see cref="ISpeciesClient"/>.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>An asynchronous task representing the operation of retrieving all the <see cref="Clients.Models.Species"/></returns>
    public static async Task<IEnumerable<Species>> GetAllAsync(this ISpeciesClient client,
        CancellationToken cancellation = default)
    {
        var species = new List<Species>();

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
        species.AddRange(firstPage.Results.Union(pages.SelectMany(p => p.Results)));

        return species;
    }
}
