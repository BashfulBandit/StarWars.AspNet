namespace StarWars.AspNet.SWAPI;

/// <summary>
/// Options to define the configuration for the <see cref="SWAPI"/> project.
/// </summary>
public class SWAPIStoreOption
{
    /// <summary>
    /// The base URL/domain of the API this project interacts with.
    /// </summary>
    public string BaseUrl { get; set; } = default!;
}
