using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Queries.Characters.Starships;

/// <summary>
/// The result of executing a <see cref="ListCharacterStarships"/> query.
/// </summary>
public sealed class ListCharacterStarshipsResult
    : QueryResult
{
    /// <inheritdoc/>
    private ListCharacterStarshipsResult(IPage<Starship> page)
        : base()
    {
        this.Page = page;
    }

    /// <inheritdoc/>
    private ListCharacterStarshipsResult(Exception error)
        : base(error)
    { }

    /// <summary>
    /// A page of the retrieved <see cref="Starship"/>.
    /// </summary>
    public IPage<Starship>? Page { get; init; } = null;

    public static ListCharacterStarshipsResult Failure(Exception error)
        => new(error);
    public static ListCharacterStarshipsResult Success(IPage<Starship> page)
        => new(page);
}
