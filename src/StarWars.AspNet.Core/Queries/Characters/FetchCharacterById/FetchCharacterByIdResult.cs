using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Characters;

/// <summary>
/// The result of executing a <see cref="FetchCharacterById"/> query.
/// </summary>
public sealed class FetchCharacterByIdResult
    : QueryResult
{
    /// <inheritdoc/>
    private FetchCharacterByIdResult(Character character)
        : base()
    {
        this.Character = character;
    }

    /// <inheritdoc/>
    private FetchCharacterByIdResult(Exception error)
        : base(error)
    { }

    /// <summary>
    /// The retrieved <see cref="Models.Character"/>.
    /// </summary>
    public Character? Character { get; init; } = null;

    public static FetchCharacterByIdResult Failure(Exception error)
        => new(error);
    public static FetchCharacterByIdResult Success(Character character)
        => new(character);
    public static FetchCharacterByIdResult NotFound(CharacterId characterId)
        => Failure(FetchCharacterByIdException.NotFound(characterId));
}
