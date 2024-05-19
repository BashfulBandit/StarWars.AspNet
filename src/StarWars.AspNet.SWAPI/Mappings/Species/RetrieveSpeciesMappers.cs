using StarWars.AspNet.Core.Models.Primitives;
using SWApiClient.Requests.Species;
using SWApiClient.Responses.Species;

namespace StarWars.AspNet.SWAPI.Mappings.Species;

internal static class RetrieveSpeciesMappers
{
    public static RetrieveSpeciesRequest ToRequest(this SpeciesId id)
        => new()
        {
            SpeciesId = id.Value
        };

    public static Core.Models.Species ToModel(this RetrieveSpeciesResponse response)
        => (response as SWApiClient.Models.Species).ToModel();
}
