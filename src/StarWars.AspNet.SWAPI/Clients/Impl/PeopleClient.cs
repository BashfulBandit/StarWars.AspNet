using RestSharp;
using StarWars.AspNet.Core.Extensions;
using StarWars.AspNet.SWAPI.Clients.Extensions;
using StarWars.AspNet.SWAPI.Clients.Interfaces;
using StarWars.AspNet.SWAPI.Clients.Options;
using StarWars.AspNet.SWAPI.Clients.Requests.People;
using StarWars.AspNet.SWAPI.Clients.Responses.People;

namespace StarWars.AspNet.SWAPI.Clients.Impl;

/// <inheritdoc />
internal class PeopleClient
    : IPeopleClient
{
    private readonly PeopleClientOptions _options;
    private readonly RestClient _client;

    public PeopleClient(PeopleClientOptions options,
        RestClient client)
    {
        this._options = options;
        this._client = client;
    }

    /// <inheritdoc />
    public async Task<ListPeopleResponse> ListAsync(ListPeopleRequest? request = null, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        // Nothing is required to make this request, so the parameter is optional/nullable. This just handles creating a default request, if none is provided.
        request ??= new();

        var restRequest = new RestRequest(this._options.ListEndpoint, Method.Get)
            .AddQueryParameter("page", request.Page);
        if (request.Search.IsPresent())
        {
            restRequest = restRequest.AddQueryParameter("search", request.Search);
        }
        var restResponse = await this._client.ExecuteAsync<ListPeopleResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }

    /// <inheritdoc />
    public async Task<RetrievePersonResponse> RetrieveAsync(RetrievePersonRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = new RestRequest(this._options.RetrieveEndpoint, Method.Get)
            .AddUrlSegment("personId", request.PersonId);
        var restResponse = await this._client.ExecuteAsync<RetrievePersonResponse>(restRequest, cancellation);
        if (restResponse.IsSuccessful) return restResponse.Data!;
        throw restResponse.BuildExceptionFromResponse();
    }
}
