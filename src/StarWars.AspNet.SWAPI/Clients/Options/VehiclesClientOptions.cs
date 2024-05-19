using SWApiClient.Impl;

namespace SWApiClient.Options;

/// <summary>
/// Options for the <see cref="StarshipsClient"/>.
/// </summary>
internal class VehiclesClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{vehicleId}";
}
