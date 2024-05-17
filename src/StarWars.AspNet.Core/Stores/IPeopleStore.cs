using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

public interface IPeopleStore
{
    Task<Person?> FetchAsync(PersonId id, CancellationToken cancellation = default);
}

public class PeopleStoreException
    : Exception
{
    public PeopleStoreException(string message)
        : base(message)
    { }

    public PeopleStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

internal class NoOpPeopleStore
    : IPeopleStore
{
    public Task<Person?> FetchAsync(PersonId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
