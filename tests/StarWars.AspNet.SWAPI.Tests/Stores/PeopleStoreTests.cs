using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class PeopleStoreTests
{
    private readonly SWAPIFixture _fixture;

    public PeopleStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidPersonId_ItShouldReturnAPerson()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IPeopleStore>();

        var personId = PersonId.From("1");
        var person = await store.FetchAsync(personId);

        Assert.NotNull(person);
        Assert.Equal(personId, person.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidPersonId_ItShouldReturnNull()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IPeopleStore>();

        var personId = PersonId.From("NotAValidPersonId");
        var person = await store.FetchAsync(personId);

        Assert.Null(person);
    }
}
