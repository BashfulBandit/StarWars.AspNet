using StarWars.AspNet.Api.Mappings.Episodes.Species;
using StarWars.AspNet.Api.Requests.Episodes;
using StarWars.AspNet.Api.Responses.Episodes.Species;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Queries.Episodes.Species;

namespace StarWars.AspNet.Api.Endpoints.Episodes.Species;

internal class ListEpisodeSpeciesEndpoint
    : FastEndpoints.Endpoint<ListEpisodeSpeciesRequest, ListEpisodeSpeciesResponse>
{
    private readonly IQueryHandler<ListEpisodeSpecies, ListEpisodeSpeciesResult> _handler;

    public ListEpisodeSpeciesEndpoint(IQueryHandler<ListEpisodeSpecies, ListEpisodeSpeciesResult> handler)
    {
        this._handler = handler;
    }

    public override void Configure()
    {
        this.Get("/");
        this.Group<SpeciesGroup>();
    }

    public override async Task HandleAsync(ListEpisodeSpeciesRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var query = request.ToQuery();
            var result = await this._handler.HandleAsync(query, cancellation);
            if (!result.Succeeded) throw result.Error;
            var response = result.ToResponse();
            await this.SendOkAsync(response, cancellation);
        }
        catch (ListEpisodeSpeciesException ex)
            when (ex.FailureReason == ListEpisodeSpeciesFailureReason.EpisodeNotFound)
        {
            await this.SendNotFoundAsync(cancellation);
        }
    }
}
