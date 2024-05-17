using System.Text.Json.Serialization;
using System.Text.Json;
using RestSharp;
using RestSharp.Serializers.Json;
using StarWars.AspNet.Client.Http.Extensions;
using StarWars.AspNet.Client.Responses;

namespace StarWars.AspNet.Client.Http;

public class StarWarsClient
    : IStarWarsClient
{
    public const string HealthCheckEndpoint = "/api/healthz";
    public const string PopulationEndpoint = "/api/population";

    private readonly RestClient _client;

    public StarWarsClient(StarWarsClientOptions options)
    {
        options.Validate();

        var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        serializerOptions.Converters.Add(new JsonStringEnumConverter());

        this._client = new RestClient(new RestClientOptions(options.BaseUrl),
            useClientFactory: true,
            configureSerialization: s => s.UseSystemTextJson(serializerOptions));

        this.Episodes = new EpisodesClient(this._client);
        this.People = new PeopleClient(this._client);
    }

    /// <inheritdoc/>
    public IStarWarsClient.IPeopleClient People { get; }

    /// <inheritdoc/>
    public IStarWarsClient.IEpisodesClient Episodes { get; }

    /// <inheritdoc/>
    public async Task<GetPopulationResponse> GetPopulationAsync(CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(PopulationEndpoint, Method.Get);
        var restResponse = await this._client.ExecuteAsync<GetPopulationResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }

    /// <inheritdoc/>
    public async Task HealthCheckAsync(CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(HealthCheckEndpoint, Method.Get);
        var restRespone = await this._client.ExecuteAsync(restRequest, cancellation);
        if (!restRespone.IsSuccessful) throw restRespone.BuildException();
    }
}
