using Gui.ViewModels.Application;
using Gui.Views.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Gui.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddGui(this IServiceCollection services)
    {
        services
            .AddScoped<IMainViewModel, MainViewModel>()
            .AddTransient<MainView>();
        
        return services;
    }
}