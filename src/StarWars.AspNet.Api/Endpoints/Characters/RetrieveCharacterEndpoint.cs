using System.Net;
using StarWars.AspNet.Api.Mappings.Characters;
using StarWars.AspNet.Api.Requests.Characters;
using StarWars.AspNet.Api.Responses.Characters;
using StarWars.AspNet.Core.Queries;
using StarWars.AspNet.Core.Queries.Characters;

namespace StarWars.AspNet.Api.Endpoints.Characters;

internal class RetrieveCharacterEndpoint
    : FastEndpoints.Endpoint<RetrieveCharacterRequest, RetrieveCharacterResponse>
{
    private readonly IQueryHandler<FetchCharacterById, FetchCharacterByIdResult> _handler;

    public RetrieveCharacterEndpoint(IQueryHandler<FetchCharacterById, FetchCharacterByIdResult> handler)
    {
        this._handler = handler;
    }

    public override void Configure()
    {
        this.Get("{characterId}");
        this.Group<CharactersGroup>();
    }

    public override async Task HandleAsync(RetrieveCharacterRequest request, CancellationToken cancellation = default)
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
        catch (FetchCharacterByIdException ex)
            when (ex.FailureReason == FetchCharacterByIdFailureReason.CharacterNotFound)
        {
            await this.SendNotFoundAsync(cancellation);
        }
    }
}

internal class RetrieveCharacterSummary
    : FastEndpoints.Summary<RetrieveCharacterEndpoint>
{
    public RetrieveCharacterSummary()
    {
        this.Summary = "Retrieve a character by identifier.";
        this.Description = "Retrieve a character by identifier.";
        this.ExampleRequest = new RetrieveCharacterRequest()
        {
            CharacterId = "1"
        };
        this.Response((int) HttpStatusCode.OK, "Successfully retrieved a character.", "application/json",
            new RetrieveCharacterResponse()
            {
                Character = new()
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
            });
        this.Response((int) HttpStatusCode.NotFound, "Unable to locate the character by identifier.");
    }
}
