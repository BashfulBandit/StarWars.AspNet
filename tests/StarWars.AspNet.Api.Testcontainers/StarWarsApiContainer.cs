using DotNet.Testcontainers.Containers;

namespace StarWars.AspNet.Api.Testcontainers;

public class StarWarsApiContainer
    : DockerContainer
{
    private readonly StarWarsApiConfiguration _configuration;

    public StarWarsApiContainer(StarWarsApiConfiguration configuration)
        : base(configuration)
    {
        this._configuration = configuration;
    }
}
