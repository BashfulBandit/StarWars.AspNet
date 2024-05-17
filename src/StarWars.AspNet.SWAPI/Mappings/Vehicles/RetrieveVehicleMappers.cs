using StarWars.AspNet.Core.Models;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Clients.Requests.Vehicles;
using StarWars.AspNet.SWAPI.Clients.Responses.Vehicles;

namespace StarWars.AspNet.SWAPI.Mappings.Vehicles;

internal static class RetrieveVehicleMappers
{
    public static RetrieveVehicleRequest ToRequest(this VehicleId id)
        => new()
        {
            VehicleId = id.Value
        };

    public static Vehicle ToModel(this RetrieveVehicleResponse response)
        => (response as Clients.Models.Vehicle).ToModel();
}
