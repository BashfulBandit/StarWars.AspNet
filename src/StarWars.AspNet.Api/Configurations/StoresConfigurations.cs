using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Api.Configurations;

internal class StoresConfigurations
{
    public const string Stores = "Stores";

    public SWAPIConfiguration? SWAPI { get; set; } = default!;

    public void Validate()
    {
        if (this.SWAPI is null)
        {
            throw new ArgumentException($"`{this.SWAPI}` cannot be null or empty.");
        }
        this.SWAPI.Validate();
    }
}

internal class SWAPIConfiguration
{
    public const string SWAPI = "SWAPI";

    public string BaseUrl { get; set; } = default!;

    public void Validate()
    {
        if (this.BaseUrl.IsMissing())
        {
            throw new ArgumentException($"`{this.BaseUrl}` cannot be null or empty.");
        }
    }
}
