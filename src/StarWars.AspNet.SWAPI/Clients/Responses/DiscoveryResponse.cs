namespace StarWars.AspNet.SWAPI.Clients.Responses;

/// <summary>
/// The Root resource provides information on all available resources within the
/// API.
/// </summary>
internal class DiscoveryResponse
{
    /// <summary>
    /// The URL root for People resources
    /// </summary>
    public Uri People { get; set; } = default!;

    /// <summary>
    /// The URL root for Planet resources
    /// </summary>
    public Uri Planets { get; set; } = default!;

    /// <summary>
    /// The URL root for Film resources
    /// </summary>
    public Uri Films { get; set; } = default!;

    /// <summary>
    /// The URL root for Species resources
    /// </summary>
    public Uri Species { get; set; } = default!;

    /// <summary>
    /// The URL root for Vehicles resources
    /// </summary>
    public Uri Vehicles { get; set; } = default!;

    /// <summary>
    /// The URL root for Starships resources
    /// </summary>
    public Uri Starships { get; set; } = default!;
}
