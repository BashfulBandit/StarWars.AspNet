using RestSharp;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.SWAPI.Clients.Extensions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Options;
using StarWars.AspNet.SWAPI.Clients.Requests.Species;
using StarWars.AspNet.SWAPI.Clients.Responses.Species;

namespace StarWars.AspNet.SWAPI.Clients.Impl;

/// <inheritdoc />
internal class SpeciesClient
    : ISpeciesClient
{
    private readonly SpeciesClientOptions _options;
    private readonly RestClient _client;

    public SpeciesClient(SpeciesClientOptions options,
        RestClient client)
    {
        this._options = options;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<ListSpeciesResponse> ListAsync(ListSpeciesRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        request ??= new();
        var restRequest = new RestRequest(this._options.ListEndpoint, Method.Get)
            .AddQueryParameter("page", request.Page);
        if (request.Search.IsPresent())
        {
            restRequest = restRequest.AddQueryParameter("search", request.Search);
        }
        var restResponse = await this._client.ExecuteAsync<ListSpeciesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }

    /// <inheritdoc />
    public async Task<RetrieveSpeciesResponse> RetrieveAsync(RetrieveSpeciesRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("speciesId", request.SpeciesId);
        var restResponse = await this._client.ExecuteAsync<RetrieveSpeciesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }
}
