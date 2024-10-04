using FastEndpoints.Swagger;
using Organization.Extensions;
using SharedKernel.Extensions;

namespace Gui.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddGui(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddSharedKernel()
            .AddOrganization(configuration)
            .SwaggerDocument(o =>
            {
                o.DocumentSettings = s =>
                {
                    s.Title = "Dotnetstore Intranet API";
                    s.Description = "API for Dotnetstore Intranet";
                    s.Version = "1.0";
                };
            })
            .AddProblemDetails();

        return services;
    }
}