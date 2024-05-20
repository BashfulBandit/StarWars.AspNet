using SWApiClient.Interfaces;
using SWApiClient.Models;
using SWApiClient.Responses.People;

namespace StarWars.AspNet.SWAPI.Extensions;

/// <summary>
/// Extension methods for an <see cref="IPeopleClient"/>.
/// </summary>
internal static class ICharactersStoreExtensions
{
    public static async Task<IEnumerable<Person>> GetAllAsync(this IPeopleClient client,
        CancellationToken cancellation = default)
    {
        var people = new List<Person>();

        var page = 0;
        ListPeopleResponse? response;
        do
        {
            response = await client.ListAsync(new()
            {
                Page = ++page
            }, cancellation);

            people.AddRange(response.Results);
        } while (response.Next is not null);

        return people;
    }
}
