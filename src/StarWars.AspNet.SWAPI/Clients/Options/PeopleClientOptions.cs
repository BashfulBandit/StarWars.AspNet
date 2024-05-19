using SWApiClient.Impl;

namespace SWApiClient.Options;

/// <summary>
/// Options for the <see cref="PeopleClient"/>.
/// </summary>
internal class PeopleClientOptions
    : ClientOptions
{
    /// <inheritdoc />
    public override string RetrieveEndpoint => this.ListEndpoint + "{personId}";
}
