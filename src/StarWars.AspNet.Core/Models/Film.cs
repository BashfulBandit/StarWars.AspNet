using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

public class Film
{
    public FilmId Id { get; set; } = FilmId.Default;

    public string Title { get; set; } = default!;

    public int ReleaseOrder { get; set; } = default!;

    public string OpeningCrawl { get; set; } = default!;

    public string Director { get; set; } = default!;

    public string Producer { get; set; } = default!;

    public DateOnly ReleaseDate { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default!;

    public DateTime UpdatedAt { get; set; } = default!;
}
