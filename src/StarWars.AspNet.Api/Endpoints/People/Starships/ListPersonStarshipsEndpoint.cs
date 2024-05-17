using StarWars.AspNet.Api.Mappings.People.Starships;
using StarWars.AspNet.Api.Requests.People.Starships;
using StarWars.AspNet.Api.Responses.People.Starships;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Queries.People.Starships;

namespace StarWars.AspNet.Api.Endpoints.People.Starships;

internal class ListPersonStarshipsEndpoint
    : FastEndpoints.Endpoint<ListPersonStarshipsRequest, ListPersonStarshipsResponse>
{
    private readonly IQueryHandler<ListPersonStarships, ListPersonStarshipsResult> _handler;

    public ListPersonStarshipsEndpoint(IQueryHandler<ListPersonStarships, ListPersonStarshipsResult> handler)
    {
        this._handler = handler;
    }

    public override void Configure()
    {
        this.Get("/");
        this.Group<PersonStarshipsGroup>();
    }

    public override async Task HandleAsync(ListPersonStarshipsRequest request, CancellationToken cancellation = default)
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
        catch (ListPersonStarshipsException ex)
            when (ex.FailureReason == ListPersonStarshipsFailureReason.PersonNotFound)
        {
            await this.SendNotFoundAsync(cancellation);
        }
    }
}
