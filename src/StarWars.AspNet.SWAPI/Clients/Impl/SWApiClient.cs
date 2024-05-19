using RestSharp;
using SWApiClient.Extensions;
using SWApiClient.Interfaces;
using SWApiClient.Options;
using SWApiClient.Responses;

namespace SWApiClient.Impl;

/// <inheritdoc />
public class SWAPIClient
    : ISWAPIClient
{
    private readonly SWAPIClientOptions _options;
    private readonly RestClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="SWAPIClient"/>.
    /// </summary>
    public SWAPIClient(SWAPIClientOptions options)
    {
        this._options = options;
        this._options.Validate();

        this._client = new RestClient
        (
            options: new RestClientOptions(options.BaseUrl),
            useClientFactory: true
        );

        // I'm not convinced I like this approach, but I also felt like this was
        // an acceptable approach. Normally, I would define the paths in the
        // clients as some constant variables. Since the API provides the
        // hypermedia URLs to build the client a bit more dynamic.
        var discovery = this.DiscoveryAsync().Result;

        this.People = new PeopleClient(new()
        {
            ListEndpoint = discovery.People.AbsolutePath
        }, this._client);
        this.Films = new FilmsClient(new()
        {
            ListEndpoint = discovery.Films.AbsolutePath
        }, this._client);
        this.Species = new SpeciesClient(new()
        {
            ListEndpoint = discovery.Species.AbsolutePath
        }, this._client);
        this.Planets = new PlanetsClient(new()
        {
            ListEndpoint = discovery.Planets.AbsolutePath
        }, this._client);
        this.Starships = new StarshipsClient(new()
        {
            ListEndpoint = discovery.Starships.AbsolutePath
        }, this._client);
        this.Vehicles = new VehiclesClient(new()
        {
            ListEndpoint = discovery.Vehicles.AbsolutePath
        }, this._client);
    }

    /// <inheritdoc />
    public IPeopleClient People { get; }

    /// <inheritdoc />
    public IFilmsClient Films { get; }

    /// <inheritdoc />
    public ISpeciesClient Species { get; }

    /// <inheritdoc />
    public IPlanetsClient Planets { get; }

    /// <inheritdoc />
    public IStarshipsClient Starships { get; }

    /// <inheritdoc />
    public IVehiclesClient Vehicles { get; }

    /// <inheritdoc />
    public async Task<DiscoveryResponse> DiscoveryAsync(CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest("api", Method.Get);
        var restResponse = await this._client.ExecuteAsync<DiscoveryResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildException();
    }
}
