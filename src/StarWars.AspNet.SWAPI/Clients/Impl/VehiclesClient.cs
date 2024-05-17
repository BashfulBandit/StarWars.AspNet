using RestSharp;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.SWAPI.Clients.Extensions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Options;
using StarWars.AspNet.SWAPI.Clients.Requests.Vehicles;
using StarWars.AspNet.SWAPI.Clients.Responses.Vehicles;

namespace StarWars.AspNet.SWAPI.Clients.Impl;

/// <inheritdoc />
internal class VehiclesClient
    : IVehiclesClient
{
    private readonly VehiclesClientOptions _options;
    private readonly RestClient _client;

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
            .AddQueryParameter("page", request.Page);
        if (request.Search.IsPresent())
        {
            restRequest = restRequest.AddQueryParameter("search", request.Search);
        }
        var restResponse = await this._client.ExecuteAsync<ListVehiclesResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }

    /// <inheritdoc />
    public async Task<RetrieveVehicleResponse> RetrieveAsync(RetrieveVehicleRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("vehicleId", request.VehicleId);
        var restResponse = await this._client.ExecuteAsync<RetrieveVehicleResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }
}
