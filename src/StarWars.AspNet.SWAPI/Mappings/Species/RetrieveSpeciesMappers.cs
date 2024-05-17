using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.SWAPI.Clients.Requests.Species;
using StarWars.AspNet.SWAPI.Clients.Responses.Species;

namespace StarWars.AspNet.SWAPI.Mappings.Species;

internal static class RetrieveSpeciesMappers
{
    public static RetrieveSpeciesRequest ToRequest(this SpeciesId id)
        => new()
        {
            SpeciesId = id.Value
        };

    public static Core.Models.Species ToModel(this RetrieveSpeciesResponse response)
        => (response as Clients.Models.Species).ToModel();
}
