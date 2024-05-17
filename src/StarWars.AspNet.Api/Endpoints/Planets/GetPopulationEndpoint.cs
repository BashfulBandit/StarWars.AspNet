using StarWars.AspNet.Api.Responses.Planets;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Queries.Planets;

namespace StarWars.AspNet.Api.Endpoints.Planets;

internal class GetPopulationEndpoint
    : FastEndpoints.EndpointWithoutRequest<GetPopulationResponse>
{
    private readonly IQueryHandler<CalculatePopulation, CalculatePopulationResult> _handler;

    public GetPopulationEndpoint(IQueryHandler<CalculatePopulation, CalculatePopulationResult> handler)
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

        var result = await this._handler.HandleAsync(CalculatePopulation.ToQuery(), cancellation);
        if (!result.Succeeded) throw result.Error;
        var response = result.ToResponse();
        await this.SendOkAsync(response, cancellation);
    }
}
