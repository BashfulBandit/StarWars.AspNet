using SWApiClient.Impl;

namespace SWApiClient.Options;

/// <summary>
/// Options for the <see cref="FilmsClient"/>.
/// </summary>
internal class FilmsClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{filmId}";
}
