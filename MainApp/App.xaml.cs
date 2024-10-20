using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetFxLib;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MainApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider? RootServiceProvider { get; private set; }

    public App()
    {
        InitHost();
    }

    private void InitHost()
    {
        // build the services
        var services = new ServiceCollection();
        services.AddLogging(lb => {
            lb.AddConsole();
            lb.AddDebug();
        });
        services.AddSingleton<SomeService>();
        this.RootServiceProvider = services.BuildServiceProvider();

        // init
        var svc = this.RootServiceProvider!.GetRequiredService<SomeService>();
        svc.DoSth();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        // clean up
        using (var mre = new ManualResetEventSlim(false))
        {
            // ...
            mre.Wait();
        }
        Environment.Exit(0);
    }
}

