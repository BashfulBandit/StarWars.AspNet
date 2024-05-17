using RestSharp;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.SWAPI.Clients.Extensions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Options;
using StarWars.AspNet.SWAPI.Clients.Requests.Planets;
using StarWars.AspNet.SWAPI.Clients.Responses.Planets;

namespace StarWars.AspNet.SWAPI.Clients.Impl;

/// <inheritdoc />
internal class PlanetsClient
    : IPlanetsClient
{
    private readonly PlanetsClientOptions _options;
    private readonly RestClient _client;

    public PlanetsClient(PlanetsClientOptions options,
        RestClient client)
    {
        this._options = options;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<ListPlanetsResponse> ListAsync(ListPlanetsRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        request ??= new();
        var restRequest = new RestRequest(this._options.ListEndpoint, Method.Get)
            .AddQueryParameter("page", request.Page);
        if (request.Search.IsPresent())
        {
            restRequest = restRequest.AddQueryParameter("search", request.Search);
        }
        var restResponse = await this._client.ExecuteAsync<ListPlanetsResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }

    /// <inheritdoc />
    public async Task<RetrievePlanetResponse> RetrieveAsync(RetrievePlanetRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("planetId", request.PlanetId);
        var restResponse = await this._client.ExecuteAsync<RetrievePlanetResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }
}
