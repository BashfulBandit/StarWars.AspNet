using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Core.Queries.Characters;

/// <summary>
/// The result of executing a <see cref="ListCharacters"/> query.
/// </summary>
public sealed class ListCharactersResult
    : QueryResult
{
    /// <inheritdoc/>
    private ListCharactersResult(IPage<Character> page)
        : base()
    {
        this.Page = page;
    }

    /// <inheritdoc/>
    private ListCharactersResult(Exception error)
        : base(error)
    { }

    /// <summary>
    /// A page of the retrieved <see cref="Starship"/>.
    /// </summary>
    public IPage<Character>? Page { get; init; } = null;

    public static ListCharactersResult Failure(Exception error)
        => new(error);
    public static ListCharactersResult Success(IPage<Character> page)
        => new(page);
}
