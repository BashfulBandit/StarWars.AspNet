using System.Text.Json;
using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using StarWars.AspNet.Api.Configurations;
using StarWars.AspNet.Core.DependencyInjection;

namespace StarWars.AspNet.Api;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServcies(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, services, configuration)
            => configuration.ReadFrom.Configuration(context.Configuration));
        builder.Services.AddHealthChecks();

        builder.Services.AddFastEndpoints();
        builder.Services.SwaggerDocument(o =>
        {
            o.ShortSchemaNames = true;
            o.DocumentSettings = settings =>
            {
                settings.Title = "StarWars.AspNet.Api";
                settings.Version = "v1.0";
            };
            o.SerializerSettings = s => s.ConfigureJsonSerializerOptions();
        });

        builder.Services.AddStarWarsCore()
            .AddStores(builder.Configuration);

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseFastEndpoints(c =>
        {
            c.Endpoints.ShortNames = true;
            c.Endpoints.RoutePrefix = "api";
            c.Endpoints.Configurator = e =>
            {
                // Remove once we get authorization figured out.
                e.AllowAnonymous();
            };
            c.Serializer.Options.ConfigureJsonSerializerOptions();
        });
        app.UseSwaggerGen(c =>
        {
            c.Path = "/api/swagger/{documentName}/swagger.json";
        },
        u =>
        {
            u.Path = "/api/swagger";
            u.DocumentPath = "/api/swagger/{documentName}/swagger.json";
        });
        app.MapHealthChecks("/api/healthz");

        return app;
    }

    public static IStarWarsBuilder AddStores(this IStarWarsBuilder builder,
        IConfiguration configuration)
    {
        var storeConfigurations = new StoresConfigurations();
        configuration.GetSection(StoresConfigurations.Stores).Bind(storeConfigurations);
        storeConfigurations.Validate();

        builder.AddSWAPIStores(o =>
        {
            o.BaseUrl = storeConfigurations.SWAPI!.BaseUrl;
        });
        return builder;
    }

    private static void ConfigureJsonSerializerOptions(this JsonSerializerOptions options)
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }
}
