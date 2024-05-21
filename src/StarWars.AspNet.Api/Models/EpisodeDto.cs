using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Api.Models;

/// <summary>
/// Model of an episode in the Star Wars series.
/// </summary>
public class EpisodeDto
{
    /// <summary>
    /// The unique identifier of the episode.
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// The title of the episode.
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// The episode number to represent the order in which this episode was
    /// released with the other episodes.
    /// </summary>
    public int ReleaseOrder { get; set; } = default!;

    /// <summary>
    /// A signature device of the opening sequences of every numbered film of
    /// the Star Wars series
    /// </summary>
    public string OpeningCrawl { get; set; } = default!;

    /// <summary>
    /// The director of the episode.
    /// </summary>
    public string Director { get; set; } = default!;

    /// <summary>
    /// The producer of the episode.
    /// </summary>
    public string Producer { get; set; } = default!;

    /// <summary>
    /// The data the episode was released.
    /// </summary>
    public DateOnly ReleaseDate { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = default!;

    /// <summary>
    /// The date and time this resource was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = default!;
}

internal static class EpisodeDtoExtensions
{
    public static EpisodeDto ToDto(this Episode model)
        => new()
        {
            Id = model.Id.Value,
            Title = model.Title,
            ReleaseOrder = model.ReleaseOrder,
            OpeningCrawl = model.OpeningCrawl,
            Director = model.Director,
            Producer = model.Producer,
            ReleaseDate = model.ReleaseDate,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
}
