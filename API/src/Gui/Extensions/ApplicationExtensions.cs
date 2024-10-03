namespace Gui.Extensions;

internal static class ApplicationExtensions
{
    private static WebApplication _app = null!;
    
    internal static async ValueTask StartApplicationAsync(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddGui();

        builder
            .BuildApplication();

        await _app.RunApplicationAsync();
    }
    
    private static void BuildApplication(this WebApplicationBuilder builder)
    {
        _app = builder.Build();
    }

    private static async ValueTask RunApplicationAsync(this WebApplication app)
    {
        await app.RunAsync();
    }
}