using System.Windows;
using Gui.Extensions;
using Gui.ViewModels.Application;
using Gui.Views.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private readonly IServiceCollection _services = new ServiceCollection();
    private ServiceProvider _serviceProvider = null!;
    
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        AddServices();
        RunApplication();
    }
    
    private void AddServices()
    {
        _services
            .AddGui();
        
        _serviceProvider = _services.BuildServiceProvider();
    }
    
    private void RunApplication()
    {
        var mainView = _serviceProvider.GetRequiredService<MainView>();
        var mainViewModel = _serviceProvider.GetRequiredService<IMainViewModel>();
        mainView.DataContext = mainViewModel;
        mainView.Show();
    }
}