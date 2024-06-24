using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TemplateCreator.Features.Template;

namespace TemplateCreator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost host;

    protected override void OnStartup(StartupEventArgs e)
    {
        host = CreateHostBuilder([]).Build();
        this.MainWindow = host.Services.GetRequiredService<MainWindow>();
        MainWindow.Visibility = Visibility.Visible;
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        //.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder)
        //    => configurationBuilder.AddUserSecrets(typeof(App).Assembly))
        .ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<TemplateMVVM>();
            services.AddSingleton<TemplateView>();

            //services.AddSingleton<WeakReferenceMessenger>();
            //services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider => provider.GetRequiredService<WeakReferenceMessenger>());

            //services.AddSingleton(_ => Current.Dispatcher);

            //services.AddTransient<ISnackbarMessageQueue>(provider =>
            //{
            //    Dispatcher dispatcher = provider.GetRequiredService<Dispatcher>();
            //    return new SnackbarMessageQueue(TimeSpan.FromSeconds(3.0), dispatcher);
            //});
        });
}
