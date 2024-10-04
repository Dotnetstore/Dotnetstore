using FastEndpoints;
using FastEndpoints.Swagger;

namespace Gui.Extensions;

internal static class ApplicationExtensions
{
    private static WebApplication _app = null!;
    
    internal static async ValueTask StartApplicationAsync(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddGui(builder.Configuration);

        builder
            .BuildApplication();
        
        _app
            .AddMiddleWare();

        await _app.RunApplicationAsync();
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