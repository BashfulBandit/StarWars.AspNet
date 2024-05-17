using StarWars.AspNet.Client.Requests.Episodes.Species;
using StarWars.AspNet.Client.Responses.Episodes.Species;

namespace StarWars.AspNet.Client;

public interface IEpisodeSpeciesClient
{
    Task<ListEpisodeSpeciesResponse> ListAsync(ListEpisodeSpeciesRequest request, CancellationToken cancellation = default);
}
