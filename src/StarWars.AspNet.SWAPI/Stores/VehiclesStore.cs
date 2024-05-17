using Microsoft.Extensions.Logging;
using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Clients.Exceptions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Mappings.Vehicles;

namespace StarWars.AspNet.SWAPI.Stores;

internal class VehiclesStore
    : IVehiclesStore
{
    private readonly ILogger<VehiclesStore> _logger;
    private readonly ISWAPIClient _client;

    public VehiclesStore(ILogger<VehiclesStore> logger,
        ISWAPIClient client)
    {
        this._logger = logger;
        this._client = client;
    }

    public async Task<Vehicle?> FetchAsync(VehicleId id, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        try
        {
            var request = id.ToRequest();
            var response = await this._client.Vehicles.RetrieveAsync(request, cancellation);
            return response.ToModel();
        }
        catch (SWAPIClientNotFoundException)
        {
            return null;
        }
        catch (Exception ex)
        {
            this._logger.LogDebug(ex, "Failed to fetch Vehicle {vehicleId}.", id.Value);
            throw new VehiclesStoreException($"{nameof(this.FetchAsync)} error for `{id.Value}`.", ex);
        }
    }
}
