namespace StarWars.AspNet.Client;

public interface IEpisodesClient
{
    IEpisodeSpeciesClient Species { get; }
}
