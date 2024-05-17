using StarWars.AspNet.SWAPI.Clients.Impl;

namespace StarWars.AspNet.SWAPI.Clients.Options;

/// <summary>
/// Options for the <see cref="PeopleClient"/>.
/// </summary>
internal class PeopleClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{personId}";
}
