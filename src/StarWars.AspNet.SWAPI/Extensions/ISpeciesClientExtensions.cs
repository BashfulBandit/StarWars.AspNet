using SWApiClient.Interfaces;
using SWApiClient.Models;
using SWApiClient.Responses.Species;

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
