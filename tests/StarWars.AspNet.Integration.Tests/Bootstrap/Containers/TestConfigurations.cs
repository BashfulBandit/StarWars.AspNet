using StarWars.AspNet.Api.Testcontainers;

namespace StarWars.AspNet.Integration.Tests.Bootstrap.Containers;

internal static class TestConfigurations
{
    public const string Namespace = "starwars.aspnet.integration.tests";
}

internal static class StarWarsApiConfigurations
{
    public const ushort HttpHostPort = 8080;
    public const ushort HttpContainerPort = 80;
    public const ushort HttpsHostPort = 8081;
    public const ushort HttpsContainerPort = 443;

    public const string Hostname = $"{TestConfigurations.Namespace}.api";

    public static readonly string BaseUrlForContainerCommunication =
        $"http://{Hostname}:{HttpContainerPort}";
    public static readonly string BaseUrlForHostCommunication =
        $"http://localhost:{HttpHostPort}";

    public static readonly StoresConfigurations Stores = new()
    {
        SWAPI = new()
        {
            BaseUrl = "https://swapi.dev"
        }
    };
}
