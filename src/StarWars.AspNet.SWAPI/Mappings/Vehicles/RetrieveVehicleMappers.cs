using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using SWApiClient.Requests.Vehicles;
using SWApiClient.Responses.Vehicles;

namespace StarWars.AspNet.SWAPI.Mappings.Vehicles;

internal static class RetrieveVehicleMappers
{
    public static RetrieveVehicleRequest ToRequest(this VehicleId id)
        => new()
        {
            VehicleId = id.Value
        };

    public static Vehicle ToModel(this RetrieveVehicleResponse response)
        => (response as SWApiClient.Models.Vehicle).ToModel();
}
