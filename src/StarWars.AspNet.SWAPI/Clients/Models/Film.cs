using System.Text.Json.Serialization;

namespace StarWars.AspNet.SWAPI.Clients.Models;

/// <summary>
/// A Film resource is a single film.
/// </summary>
internal class Film
{
    /// <summary>
    /// The title of this film.
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// The episode number of this film.
    /// </summary>
    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; } = default;

    /// <summary>
    /// The opening paragraphs at the beginning of this film.
    /// </summary>
    [JsonPropertyName("opening_crawl")]
    public string OpeningCrawl { get; set; } = default!;

    /// <summary>
    /// The name of the director of this film.
    /// </summary>
    public string Director { get; set; } = default!;

    /// <summary>
    /// The name(s) of the producer(s) of this film. Comma separated.
    /// </summary>
    public string Producer { get; set; } = default!;

    /// <summary>
    /// The ISO 8601 date format of film release at original creator country.
    /// </summary>
    [JsonPropertyName("release_date")]
    public DateOnly ReleaseDate { get; set; } = default!;

    /// <summary>
    /// An array of people resource URLs that are in this film.
    /// </summary>
    public IEnumerable<Uri> Characters { get; set; } = default!;

    /// <summary>
    /// An array of planet resource URLs that are in this film.
    /// </summary>
    public IEnumerable<Uri> Planets { get; set; } = default!;

    /// <summary>
    /// An array of starship resource URLs that are in this film.
    /// </summary>
    public IEnumerable<Uri> Starships { get; set; } = default!;

    /// <summary>
    /// An array of vehicle resource URLs that are in this film.
    /// </summary>
    public IEnumerable<Uri> Vehicles { get; set; } = default!;

    /// <summary>
    /// An array of species resource URLs that are in this film.
    /// </summary>
    public IEnumerable<Uri> Species { get; set; } = default!;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was created.
    /// </summary>
    public DateTime Created { get; set; } = default!;

    /// <summary>
    /// The ISO 8601 date format of the time that this resource was edited.
    /// </summary>
    public DateTime Edited { get; set; } = default!;

    /// <summary>
    /// The hypermedia URL of this resource.
    /// </summary>
    public Uri Url { get; set; } = default!;
}
