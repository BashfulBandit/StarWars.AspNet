using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Stores;

/// <summary>
/// Interface to provide operations for a store which manages <see cref="Character"/>.
/// </summary>
public interface ICharactersStore
{
    /// <summary>
    /// Retrieves a <see cref="Character"/> by id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Character"/> to retrieve.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <returns>The <see cref="Character"/>.</returns>
    Task<Character?> FetchAsync(CharacterId id, CancellationToken cancellation = default);
}

/// <summary>
/// An exception representing a failed operation against the <see cref="ICharactersStore"/>.
/// </summary>
public class CharactersStoreException
    : Exception
{
    /// <inheritdoc/>
    public CharactersStoreException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public CharactersStoreException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// Basic NoOp implementation of <see cref="ICharactersStore"/>.
/// </summary>
/// <remarks>
/// This is mostly just to ensure DI doesn't fail at startup. This is definitely
/// not necessary, but just something I have been doing.
/// </remarks>
internal class NoOpCharactersStore
    : ICharactersStore
{
    /// <inheritdoc/>
    public Task<Character?> FetchAsync(CharacterId id, CancellationToken cancellation = default)
        => throw new NotImplementedException();
}
