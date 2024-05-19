using RestSharp;
using SWApiClient.Extensions;
using SWApiClient.Interfaces;
using SWApiClient.Options;
using SWApiClient.Requests.Films;
using SWApiClient.Responses.Films;

namespace SWApiClient.Impl;

/// <inheritdoc />
internal class FilmsClient
    : IFilmsClient
{
    private readonly FilmsClientOptions _options;
    private readonly RestClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="FilmsClient"/>.
    /// </summary>
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
            .AddQueryParameters(request);
        var restResponse = await this._client.ExecuteAsync<ListFilmsResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }

    /// <inheritdoc />
    public async Task<RetrieveFilmResponse> RetrieveAsync(RetrieveFilmRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("filmId", request.FilmId);
        var restResponse = await this._client.ExecuteAsync<RetrieveFilmResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
