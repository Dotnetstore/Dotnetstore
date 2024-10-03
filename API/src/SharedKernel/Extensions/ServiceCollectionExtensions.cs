using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services)
    {
        services
            .AddFastEndpoints();

        return services;
    }
}