using System.Net;
using StarWars.AspNet.Api.Mappings.Episodes;
using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Episodes;
using StarWars.AspNet.Api.Responses.Episodes;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Queries.Episodes;

namespace StarWars.AspNet.Api.Endpoints.Episodes;

internal class ListEpisodesEndpoint
    : FastEndpoints.Endpoint<ListEpisodesRequest, ListEpisodesResponse>
{
    private readonly IQueryHandler<ListEpisodes, ListEpisodesResult> _handler;

    public ListEpisodesEndpoint(IQueryHandler<ListEpisodes, ListEpisodesResult> handler)
    {
        this._handler = handler;
    }

    public override void Configure()
    {
        this.Get("/");
        this.Group<EpisodesGroup>();
    }

    public override async Task HandleAsync(ListEpisodesRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var query = request.ToQuery();
        var result = await this._handler.HandleAsync(query, cancellation);
        if (!result.Succeeded) throw result.Error;
        var response = result.ToResponse();
        await this.SendOkAsync(response, cancellation);
    }
}

internal class ListEpisodesSummary
    : FastEndpoints.Summary<ListEpisodesEndpoint>
{
    public ListEpisodesSummary()
    {
        this.Summary = "Retrieve a paginated, filtered, and sorted list of Star Wars episodes.";
        this.Description = "Retrieve a paginated, filtered, and sorted list of Star Wars episodes.";
        this.ExampleRequest = new ListEpisodesRequest();
        this.Response((int) HttpStatusCode.OK, "Successfully retrieved a paginated list of Star Wars episodes.", "application/json",
            new ListEpisodesResponse()
            {
                Episodes = new List<EpisodeDto>()
                {
                    new()
                    {
                        Id = "4",
                        Title = "A New Hope",
                        ReleaseOrder = 1,
                        OpeningCrawl = "It is a period of civil war.\r\nRebel spaceships, striking\r\nfrom a hidden base, have won\r\ntheir first victory against\r\nthe evil Galactic Empire.\r\n\r\nDuring the battle, Rebel\r\nspies managed to steal secret\r\nplans to the Empire's\r\nultimate weapon, the DEATH\r\nSTAR, an armored space\r\nstation with enough power\r\nto destroy an entire planet.\r\n\r\nPursued by the Empire's\r\nsinister agents, Princess\r\nLeia races home aboard her\r\nstarship, custodian of the\r\nstolen plans that can save her\r\npeople and restore\r\nfreedom to the galaxy....",
                        Director = "George Lucas",
                        Producer = "Gary Kurtz, Rick McCallum",
                        ReleaseDate = DateOnly.Parse("1977-05-25"),
                        CreatedAt = DateTime.Parse("2014-12-10T14:23:31.880000Z"),
                        UpdatedAt = DateTime.Parse("2014-12-20T19:49:45.256000Z")
                    }
                },
                Pagination = new()
                {
                    PageCount = 1,
                    PageSize = 25,
                    PageNumber = 1,
                    TotalCount = 1
                }
            });
    }
}
