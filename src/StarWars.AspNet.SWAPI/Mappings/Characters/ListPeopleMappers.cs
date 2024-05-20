using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Filters;
using StarWars.AspNet.SWAPI.Mappings.Characters;
using SWApiClient.Models;
using SWApiClient.Requests.People;
using SWApiClient.Responses.People;

namespace StarWars.AspNet.SWAPI.Mappings.Characters;

internal static class ListPeopleMappers
{
    public static ListPeopleRequest ToRequest(this CharactersSearchFilter filter)
        => new()
        {
            Page = filter.Page
        };

    public static IPage<Character> ToModel(this ListPeopleResponse response)
        => new Page<Person>(response.Results.ToList(), response.ParseCurrentPageNumber(), response.Results.Count(), response.Count)
            .MapTo(p => p.ToModel());

    public static IQueryable<Person> Filter(this IQueryable<Person> query,
        CharactersSearchFilter filter)
    {
        if (filter.Name is not null)
        {
            query = query.Where(p => p.Name == filter.Name);
        }
        return query;
    }

    public static IQueryable<Person> Sort(this IQueryable<Person> query,
        CharactersSearchFilter _)
    {
        // Currently doesn't do anything, but it is here to add later.
        return query;
    }
}
