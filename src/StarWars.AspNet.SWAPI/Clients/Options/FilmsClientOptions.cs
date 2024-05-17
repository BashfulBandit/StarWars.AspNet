using StarWars.AspNet.SWAPI.Clients.Impl;

namespace StarWars.AspNet.SWAPI.Clients.Options;

/// <summary>
/// Options for the <see cref="FilmsClient"/>.
/// </summary>
internal class FilmsClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{filmId}";
}
