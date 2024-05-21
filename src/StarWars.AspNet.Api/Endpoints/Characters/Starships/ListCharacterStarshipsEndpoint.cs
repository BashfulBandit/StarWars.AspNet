using System.Net;
using StarWars.AspNet.Api.Endpoints.Characters.Starships;
using StarWars.AspNet.Api.Mappings.Characters.Starships;
using StarWars.AspNet.Api.Models;
using StarWars.AspNet.Api.Requests.Characters.Starships;
using StarWars.AspNet.Api.Responses.Characters.Starships;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Queries.Characters.Starships;

namespace StarWars.AspNet.Api.Endpoints.Characters.Starships;

internal class ListCharacterStarshipsEndpoint
    : FastEndpoints.Endpoint<ListCharacterStarshipsRequest, ListCharacterStarshipsResponse>
{
    private readonly IQueryHandler<ListCharacterStarships, ListCharacterStarshipsResult> _handler;

    public ListCharacterStarshipsEndpoint(IQueryHandler<ListCharacterStarships, ListCharacterStarshipsResult> handler)
    {
        this._handler = handler;
    }

    public override void Configure()
    {
        this.Get("/");
        this.Group<CharacterStarshipsGroup>();
    }

    public override async Task HandleAsync(ListCharacterStarshipsRequest request, CancellationToken cancellation = default)
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
        catch (ListCharacterStarshipsException ex)
            when (ex.FailureReason == ListCharacterStarshipsFailureReason.CharacterNotFound)
        {
            await this.SendNotFoundAsync(cancellation);
        }
    }
}

internal class ListCharacterStarshipsSummary
    : FastEndpoints.Summary<ListCharacterStarshipsEndpoint>
{
    public ListCharacterStarshipsSummary()
    {
        this.Summary = "Retrieve a paginated, filtered, and sorted list of starships a Star Wars character has piloted.";
        this.Description = "Retrieve a paginated, filtered, and sorted list of starships a Star Wars character has piloted.";
        this.ExampleRequest = new ListCharacterStarshipsRequest()
        {
            CharacterId = "1"
        };
        this.Response((int) HttpStatusCode.OK, "Successfully retrieved a paginated list of starships the Star Wars character has piloted.", "application/json",
            new ListCharacterStarshipsResponse()
            {
                Starships = new List<StarshipDto>()
                {
                    new()
                    {
                        Id = "9",
                        Name = "Wookie",
                        Model = "Death Star",
                        StarshipClass = "Deep Space Mobile Battlestation",
                        Manufacturer = new List<string>()
                        {
                            "Imperial Department of Military Research",
                            "Sienar Fleet Systems"
                        },
                        CostInCredits = "1000000000000",
                        Length = "120000",
                        Crew = "342953",
                        Passengers = "843342",
                        MaxAtmospheringSpeed = "n/a",
                        HyperdriveRating = "4.0",
                        MGLT = "10 MGLT",
                        CargoCapacity = "1000000000000",
                        Consumables = "3 years",
                        CreatedAt = DateTime.Parse("2014-12-10T16:36:50.509000Z"),
                        UpdatedAt = DateTime.Parse("2014-12-10T16:36:50.509000Z")
                    }
                },
                Pagination = new()
                {
                    PageCount = 1,
                    PageSize = 5,
                    PageNumber = 1,
                    TotalCount = 1
                }
            });
        this.Response((int) HttpStatusCode.NotFound, "Unable to locate the character by identifier.");
    }
}
