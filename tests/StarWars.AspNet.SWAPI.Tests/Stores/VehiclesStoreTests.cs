using Microsoft.Extensions.DependencyInjection;
using StarWars.AspNet.Core.Models.Primitives;
using StarWars.AspNet.Core.Stores;
using StarWars.AspNet.SWAPI.Tests.Bootstrap.Fixtures;

namespace StarWars.AspNet.SWAPI.Tests.Stores;

[Collection(nameof(SWAPICollection))]
public class VehiclesStoreTests
{
    private readonly SWAPIFixture _fixture;

    public VehiclesStoreTests(SWAPIFixture fixture)
    {
        this._fixture = fixture;
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAValidVehicleId_ItShouldReturnAVehicle()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IVehiclesStore>();

        var vehicleId = VehicleId.From("4");
        var vehicle = await store.FetchAsync(vehicleId);

        Assert.NotNull(vehicle);
        Assert.Equal(vehicleId, vehicle.Id);
    }

    [Fact]
    public async Task FetchAsync_WhenGivenAnInvalidSpeciesId_ItShouldReturnNull()
    {
        using var scope = this._fixture.ServiceProvider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<IVehiclesStore>();

        var vehicleId = VehicleId.From("NotAValidVehicleId");
        var vehicle = await store.FetchAsync(vehicleId);

        Assert.Null(vehicle);
    }
}
