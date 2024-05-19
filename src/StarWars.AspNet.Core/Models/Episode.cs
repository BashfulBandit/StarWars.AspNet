using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

/// <summary>
/// Model of an episode in the Star Wars series.
/// </summary>
public class Episode
{
    /// <summary>
    /// The unique identifier of the episode.
    /// </summary>
    public EpisodeId Id { get; set; } = EpisodeId.Default;

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
