using RestSharp;
using SWApiClient.Extensions;
using SWApiClient.Interfaces;
using SWApiClient.Options;
using SWApiClient.Requests.Planets;
using SWApiClient.Responses.Planets;

namespace SWApiClient.Impl;

/// <inheritdoc />
internal class PlanetsClient
    : IPlanetsClient
{
    private readonly PlanetsClientOptions _options;
    private readonly RestClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlanetsClient"/>.
    /// </summary>
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
            .AddQueryParameters(request);
        var restResponse = await this._client.ExecuteAsync<ListPlanetsResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }

    /// <inheritdoc />
    public async Task<RetrievePlanetResponse> RetrieveAsync(RetrievePlanetRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("planetId", request.PlanetId);
        var restResponse = await this._client.ExecuteAsync<RetrievePlanetResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
