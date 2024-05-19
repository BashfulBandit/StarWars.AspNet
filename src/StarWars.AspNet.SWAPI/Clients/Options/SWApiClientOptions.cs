using StarWars.AspNet.Core.Extensions;
using SWApiClient.Impl;

namespace SWApiClient.Options;

/// <summary>
/// Options to define the configuration of the <see cref="SWAPIClient"/>.
/// </summary>
public class SWAPIClientOptions
{
    /// <summary>
    /// The base url/domain for the Star Wars API the request will be made
    /// against.
    /// </summary>
    public string BaseUrl { get; set; } = default!;

    /// <summary>
    /// Validate the instance of the <see cref="SWAPIClientOptions"/>.
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Exception thrown if the instance is invalidate for it's usage.
    /// </exception>
    public void Validate()
    {
        var errors = new List<string>();

        if (this.BaseUrl.IsMissing())
        {
            errors.Add($"`{nameof(this.BaseUrl)}` cannot be null or empty.");
        }

        if (errors.Any())
        {
            throw new ArgumentException($"{nameof(SWAPIClientOptions)} errors:\n\t * {string.Join("\n\t * ", errors)}");
        }
    }
}
