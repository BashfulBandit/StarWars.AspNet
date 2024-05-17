using StarWars.AspNet.SWAPI.Clients.Impl;

namespace StarWars.AspNet.SWAPI.Clients.Options;

/// <summary>
/// Options for the <see cref="PlanetsClient"/>.
/// </summary>
internal class SpeciesClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{speciesId}";
}
