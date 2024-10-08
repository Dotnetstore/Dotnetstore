﻿using FastEndpoints;
using FastEndpoints.Swagger;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;

namespace Gui.Extensions;

internal static class ApplicationExtensions
{
    private static WebApplication _app = null!;
    
    internal static async ValueTask StartApplicationAsync(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddGui(builder.Configuration);

        builder
            .SetupLogging()
            .BuildApplication();
        
        _app
            .AddMiddleWare();

        await _app.RunApplicationAsync();
    }
    
    private static WebApplicationBuilder SetupLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddOpenTelemetry(x =>
        {
            x.AddOtlpExporter(a =>
            {
                a.Endpoint = new Uri("http://localhost:5341/ingest/otlp/v1/logs");
                a.Protocol = OtlpExportProtocol.HttpProtobuf;
                a.Headers = "X-Seq-ApiKey=30WDqemdJUfvEbCIdyXO";
            });
        });

        return builder;
    }
    
    private static void BuildApplication(this WebApplicationBuilder builder)
    {
        _app = builder.Build();
    }

    private static void AddMiddleWare(this WebApplication app)
    {
        app
            .UseFastEndpoints()
            .UseSwaggerGen()
            .UseExceptionHandler();
    }

    private static async ValueTask RunApplicationAsync(this WebApplication app)
    {
        await app.RunAsync();
    }
}