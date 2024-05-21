using SWApiClient.Interfaces;
using SWApiClient.Models;
using SWApiClient.Responses.Films;

namespace StarWars.AspNet.SWAPI.Extensions;

internal static class IFilmClientExtensions
{
    public static async Task<IEnumerable<Film>> GetAllAsync(this IFilmsClient client,
        CancellationToken cancellation = default)
    {
        var films = new List<Film>();

        var page = 0;
        ListFilmsResponse? response;
        do
        {
            response = await client.ListAsync(new()
            {
                Page = ++page
            }, cancellation);

            films.AddRange(response.Results);
        } while (response.Next is not null);

        return films;
    }
}
