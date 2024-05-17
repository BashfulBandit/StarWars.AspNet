using RestSharp;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.SWAPI.Clients.Extensions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Options;
using StarWars.AspNet.SWAPI.Clients.Requests.Starships;
using StarWars.AspNet.SWAPI.Clients.Responses.Starships;

namespace StarWars.AspNet.SWAPI.Clients.Impl;

/// <inheritdoc />
internal class StarshipsClient
    : IStarshipsClient
{
    private readonly StarshipsClientOptions _options;
    private readonly RestClient _client;

    public StarshipsClient(StarshipsClientOptions options,
        RestClient client)
    {
        this._options = options;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<ListStarshipsResponse> ListAsync(ListStarshipsRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        request ??= new();
        var restRequest = new RestRequest(this._options.ListEndpoint, Method.Get)
            .AddQueryParameter("page", request.Page);
        if (request.Search.IsPresent())
        {
            restRequest = restRequest.AddQueryParameter("search", request.Search);
        }
        var restResponse = await this._client.ExecuteAsync<ListStarshipsResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }

    /// <inheritdoc />
    public async Task<RetrieveStarshipResponse> RetrieveAsync(RetrieveStarshipRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("starshipId", request.StarshipId);
        var restResponse = await this._client.ExecuteAsync<RetrieveStarshipResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }
}
