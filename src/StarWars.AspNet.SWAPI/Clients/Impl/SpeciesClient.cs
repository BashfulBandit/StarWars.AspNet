using RestSharp;
using SWApiClient.Extensions;
using SWApiClient.Interfaces;
using SWApiClient.Options;
using SWApiClient.Requests.Species;
using SWApiClient.Responses.Species;

namespace SWApiClient.Impl;

/// <inheritdoc />
internal class SpeciesClient
    : ISpeciesClient
{
    private readonly SpeciesClientOptions _options;
    private readonly RestClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpeciesClient"/>.
    /// </summary>
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
            .AddQueryParameters(request);
        var restResponse = await this._client.ExecuteAsync<ListSpeciesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }

    /// <inheritdoc />
    public async Task<RetrieveSpeciesResponse> RetrieveAsync(RetrieveSpeciesRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("speciesId", request.SpeciesId);
        var restResponse = await this._client.ExecuteAsync<RetrieveSpeciesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
