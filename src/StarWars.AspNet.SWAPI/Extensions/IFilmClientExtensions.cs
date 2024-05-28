using SWApiClient.Interfaces;
using SWApiClient.Models;

namespace StarWars.AspNet.SWAPI.Extensions;

internal static class IFilmClientExtensions
{
    public static async Task<IEnumerable<Film>> GetAllAsync(this IFilmsClient client,
        CancellationToken cancellation = default)
    {
        var films = new List<Film>();

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
        films.AddRange(firstPage.Results.Union(pages.SelectMany(p => p.Results)));

        return films;
    }
}
