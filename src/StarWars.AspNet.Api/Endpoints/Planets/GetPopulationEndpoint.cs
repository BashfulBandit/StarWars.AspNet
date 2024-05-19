using System.Net;
using StarWars.AspNet.Api.Mappings.Planets;
using StarWars.AspNet.Api.Responses.Planets;
using StarWars.AspNet.Core.Commands;
using StarWars.AspNet.Core.Commands.Planets;

namespace StarWars.AspNet.Api.Endpoints.Planets;

internal class GetPopulationEndpoint
    : FastEndpoints.EndpointWithoutRequest<GetPopulationResponse>
{
    private readonly ICommandHandler<CalculatePopulation, CalculatePopulationResult> _handler;

    public GetPopulationEndpoint(ICommandHandler<CalculatePopulation, CalculatePopulationResult> handler)
    {
        this._handler = handler;
    }

    public override void Configure()
    {
        this.Get("population/");
    }

    public override async Task HandleAsync(CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var result = await this._handler.HandleAsync(CalculatePopulation.ToCommand(), cancellation);
        if (!result.Succeeded) throw result.Error;
        var response = result.ToResponse();
        await this.SendOkAsync(response, cancellation);
    }
}

internal class GetPopulationSummary
    : FastEndpoints.Summary<GetPopulationEndpoint>
{
    public GetPopulationSummary()
    {
        this.Summary = "Get the total known population of the Star Wars universe.";
        this.Description = "Get the total known population of the Star Wars universe.";
        this.Response((int) HttpStatusCode.OK, "Successfully retrieved the total known population of the Star Wars universe.", "application/json",
            new GetPopulationResponse()
            {
                Population = 1_711_401_432_500
            });
    }
}
