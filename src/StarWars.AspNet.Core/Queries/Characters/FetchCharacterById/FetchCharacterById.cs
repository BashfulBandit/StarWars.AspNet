using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Queries.Characters;

/// <summary>
/// Query to retrieve a <see cref="Models.Character"/> by the provided identifier.
/// </summary>
public sealed class FetchCharacterById
    : IQuery<FetchCharacterByIdResult>
{
    private FetchCharacterById(CharacterId characterId)
    {
        this.CharacterId = characterId;
    }

    /// <summary>
    /// The provided identifier.
    /// </summary>
    public CharacterId CharacterId { get; } = default!;

    public static FetchCharacterById ToQuery(CharacterId characterId)
        => new(characterId);
}
