using Microsoft.Extensions.DependencyInjection;

namespace StarWars.AspNet.Core.DependencyInjection;

public interface IStarWarsBuilder
{
    public IServiceCollection Services { get; }
}

internal class StarWarsBuilder
        : IStarWarsBuilder
{
    public StarWarsBuilder(IServiceCollection services)
    {
        this.Services = services;
    }

    public IServiceCollection Services { get; init; }
}
