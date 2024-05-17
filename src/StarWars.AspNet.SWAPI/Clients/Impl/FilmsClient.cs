using RestSharp;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.SWAPI.Clients.Extensions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Options;
using StarWars.AspNet.SWAPI.Clients.Requests.Films;
using StarWars.AspNet.SWAPI.Clients.Responses.Films;

namespace StarWars.AspNet.SWAPI.Clients.Impl;

/// <inheritdoc />
internal class FilmsClient
    : IFilmsClient
{
    private readonly FilmsClientOptions _options;
    private readonly RestClient _client;

    public FilmsClient(FilmsClientOptions options,
        RestClient client)
    {
        this._options = options;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<ListFilmsResponse> ListAsync(ListFilmsRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        request ??= new();
        var restRequest = new RestRequest(this._options.ListEndpoint, Method.Get)
            .AddQueryParameter("page", request.Page);
        if (request.Search.IsPresent())
        {
            restRequest = restRequest.AddQueryParameter("search", request.Search);
        }
        var restResponse = await this._client.ExecuteAsync<ListFilmsResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }

    /// <inheritdoc />
    public async Task<RetrieveFilmResponse> RetrieveAsync(RetrieveFilmRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("filmId", request.FilmId);
        var restResponse = await this._client.ExecuteAsync<RetrieveFilmResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }
}
