namespace StarWars.AspNet.SWAPI.Clients.Options;

/// <summary>
/// Base abstract class to define a client options.
/// </summary>
internal abstract class ClientOptions
{
    /// <summary>
    /// The path to the list resources endpoint for the client.
    /// </summary>
    public string ListEndpoint { get; init; } = default!;

    /// <summary>
    /// The path to the retrieve resource endpoint for the client.
    /// </summary>
    public abstract string RetrieveEndpoint { get; }
}
