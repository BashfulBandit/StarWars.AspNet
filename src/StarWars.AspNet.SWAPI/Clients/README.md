# SWAPIClient

A C# helper library for [SWAPI](https://swapi.dev) - the Star Wars API

## Usage

All resources are accesible through the top-level ISWApiClient.

```csharp
var options = new SWApiClientOptions()
{
    BaseUrl = "< base url to SW API >"
};
var swApiClient = new SWApiClient(options);
```

You can also make use of the `IServiceCollection` extension method to add the
dependencies. Below is an example usage:

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Will register the internal `SWApiClient` as an `ISWApiClient` using the default
// configuration.
services.AddSWAPIClient();

// Will register the internal `SWApiClient` as an `ISWApiClient` using the
// provided configuration to override the default configuration.
services.AddSWAPIClient(o =>
{
    o.BaseUrl = "< base url to SW API >"
})
```

