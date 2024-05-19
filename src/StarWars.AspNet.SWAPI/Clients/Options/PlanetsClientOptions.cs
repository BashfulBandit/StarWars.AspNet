using SWApiClient.Impl;

namespace SWApiClient.Options;

/// <summary>
/// Options for the <see cref="PlanetsClient"/>.
/// </summary>
internal class PlanetsClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{planetId}";
}
