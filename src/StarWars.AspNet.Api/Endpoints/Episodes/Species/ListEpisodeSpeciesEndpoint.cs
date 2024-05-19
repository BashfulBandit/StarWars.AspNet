using System.Net;
using StarWars.AspNet.Api.Mappings.Episodes.Species;
using StarWars.AspNet.Api.Models;
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
        this.Group<EpisodeSpeciesGroup>();
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

internal class ListEpisodeSpeciesSummary
    : FastEndpoints.Summary<ListEpisodeSpeciesEndpoint>
{
    public ListEpisodeSpeciesSummary()
    {
        this.Summary = "Retrieve a paginated, filtered, and sorted list of species in a Star Wars episode.";
        this.Description = "Retrieve a paginated, filtered, and sorted list of species in a Star Wars episode.";
        this.ExampleRequest = new ListEpisodeSpeciesRequest()
        {
            EpisodeId = "1"
        };
        this.Response((int) HttpStatusCode.OK, "Successfully retrieved the total known population of the Star Wars universe.", "application/json",
            new ListEpisodeSpeciesResponse()
            {
                Species = new List<SpeciesDto>()
                {
                    new()
                    {
                        Id = "3",
                        Name = "Wookie",
                        Classification = "Mammal",
                        Designation = "Sentient",
                        AverageHeight = "2.1",
                        AverageLifespan = "400",
                        EyeColors = new List<string>()
                        {
                            "blue",
                            "green",
                            "yellow",
                            "brown",
                            "golden",
                            "red"
                        },
                        HairColors = new List<string>()
                        {
                            "black",
                            "brown"
                        },
                        SkinColors = new List<string>()
                        {
                            "gray"
                        },
                        Language = "Shyriiwook",
                        CreatedAt = DateTime.Parse("2014-12-10T16:44:31.486000Z"),
                        UpdatedAt = DateTime.Parse("2014-12-10T16:44:31.486000Z")
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
    }
}
