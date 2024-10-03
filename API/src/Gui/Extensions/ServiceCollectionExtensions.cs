using SharedKernel.Extensions;

namespace Gui.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddGui(this IServiceCollection services)
    {
        services
            .AddSharedKernel();

        return services;
    }
}