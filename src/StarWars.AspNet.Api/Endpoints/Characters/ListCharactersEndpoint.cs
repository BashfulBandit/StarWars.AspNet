using System.Net;
using StarWars.AspNet.Api.Endpoints.Characters;
using StarWars.AspNet.Api.Mappings.Characters;
using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Characters;
using StarWars.AspNet.Api.Responses.Characters;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Queries.Characters;

namespace StarWars.AspNet.Api.Endpoints.Characters;

internal class ListCharactersEndpoint
    : FastEndpoints.Endpoint<ListCharactersRequest, ListCharactersResponse>
{
    private readonly IQueryHandler<ListCharacters, ListCharactersResult> _handler;

    public ListCharactersEndpoint(IQueryHandler<ListCharacters, ListCharactersResult> handler)
    {
        this._handler = handler;
    }

    public override void Configure()
    {
        this.Get("/");
        this.Group<CharactersGroup>();
    }

    public override async Task HandleAsync(ListCharactersRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var query = request.ToQuery();
        var result = await this._handler.HandleAsync(query, cancellation);
        if (!result.Succeeded) throw result.Error!;
        var response = result.ToResponse();
        await this.SendOkAsync(response, cancellation);
    }
}

internal class ListCharactersSummary
    : FastEndpoints.Summary<ListCharactersEndpoint>
{
    public ListCharactersSummary()
    {
        this.Summary = "Retrieve a paginated, filtered, and sorted list of Star Wars characters.";
        this.Description = "Retrieve a paginated, filtered, and sorted list of Star Wars characters.";
        this.ExampleRequest = new ListCharactersRequest()
        {
            Name = "Luke Skywalker"
        };
        this.Response((int) HttpStatusCode.OK, "Successfully retrieved a paginated list of Star Wars characters.", "application/json",
            new ListCharactersResponse()
            {
                Characters = new List<CharacterDto>()
                {
                    new()
                    {
                        Id = "1",
                        Name = "Luke Skywalker",
                        Height = "172",
                        Mass = "77",
                        HairColor = "blond",
                        SkinColor = "fair",
                        EyeColor = "blue",
                        BirthYear = "19BBY",
                        Gender = "male",
                        CreatedAt = DateTime.Parse("2014-12-09T13:50:51.644Z"),
                        UpdatedAt = DateTime.Parse("2014-12-20T21:17:56.891Z")
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
