using SWApiClient.Impl;

namespace SWApiClient.Options;

/// <summary>
/// Options for the <see cref="PlanetsClient"/>.
/// </summary>
internal class SpeciesClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{speciesId}";
}
