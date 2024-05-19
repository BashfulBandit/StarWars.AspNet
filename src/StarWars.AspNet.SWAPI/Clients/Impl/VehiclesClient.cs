using RestSharp;
using SWApiClient.Extensions;
using SWApiClient.Interfaces;
using SWApiClient.Options;
using SWApiClient.Requests.Vehicles;
using SWApiClient.Responses.Vehicles;

namespace SWApiClient.Impl;

/// <inheritdoc />
internal class VehiclesClient
    : IVehiclesClient
{
    private readonly VehiclesClientOptions _options;
    private readonly RestClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="VehiclesClient"/>.
    /// </summary>
    public VehiclesClient(VehiclesClientOptions options,
        RestClient client)
    {
        this._options = options;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<ListVehiclesResponse> ListAsync(ListVehiclesRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        request ??= new();
        var restRequest = new RestRequest(this._options.ListEndpoint, Method.Get)
            .AddQueryParameters(request);
        var restResponse = await this._client.ExecuteAsync<ListVehiclesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }

    /// <inheritdoc />
    public async Task<RetrieveVehicleResponse> RetrieveAsync(RetrieveVehicleRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("vehicleId", request.VehicleId);
        var restResponse = await this._client.ExecuteAsync<RetrieveVehicleResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
