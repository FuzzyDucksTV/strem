using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistity.Encryption;
using Photino.Blazor;
using Strem.Core.DI;
using Strem.Core.Events.Bus;
using Strem.Core.Extensions;
using Strem.Core.Flows.Executors;
using Strem.Core.Flows.Registries;
using Strem.Core.Flows.Registries.Integrations;
using Strem.Core.Flows.Registries.Tasks;
using Strem.Core.Flows.Registries.Triggers;
using Strem.Core.Plugins;
using Strem.Flows.Default.Modules;
using Strem.Infrastructure.Extensions;
using Strem.Infrastructure.Modules;
using Strem.Infrastructure.Services.Api;
using Strem.OBS.Modules;
using Strem.Twitch.Controllers;
using Strem.Twitch.Modules;
using Strem.UI;

namespace Strem;

public class Program
{
    public static PhotinoBlazorApp CreateApp(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
        appBuilder.Services.AddModules(new InfrastructureModule(), new TwitchModule(), new OBSModule(), new DefaultFlowsModule());
        appBuilder.RootComponents.Add<App>("#app");
        return appBuilder.Build();
    }

    [STAThread]
    public static void Main(string[] args)
    {
        var app = CreateApp(args);
        var pluginBootstrapper = new PluginBootstrapper(app.Services);
        var logger = app.Services.GetService<ILogger<Program>>();
        var eventBus = app.Services.GetService<IEventBus>();
        
        logger.Information("Starting Up Strem");
        
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            logger.Error(error.ExceptionObject.ToString());
            app.MainWindow.OpenAlertWindow("Fatal exception", error.ExceptionObject.ToString());
        };

        logger.Information("Starting Plugins");
        Task.Run(async () => await pluginBootstrapper.StartAllPlugins(app.Services)).Wait();
        
        //TODO: Solve this hack with webhost service collection separation
        WebHostHackExtensions.EventBus = eventBus;
        WebHostHackExtensions.ServiceLocator = app.Services;
        
        var apiHostConfiguration = new ApiHostConfiguration(
            new[] { typeof(TwitchController).Assembly },
            new IDependencyModule[] { new InfrastructureModule(), new TwitchModule() });
        
        var webHost = app.Services.GetService<IApiWebHost>();
        logger.Information("Starting Internal Host");
        webHost.StartHost(apiHostConfiguration);
        logger.Information($"Started Internal Host: http://localhost:{ApiHostConfiguration.ApiHostPort}");
        
        app.MainWindow
            .SetTitle("Strem")
            .SetDevToolsEnabled(true)
            .SetSize(1920, 1080)
            .SetUseOsDefaultSize(false)
            .Load("./wwwroot/index.html");
        
        logger.Information("Starting Flow Execution Engine");
        Task.Run(async () => await pluginBootstrapper.StartExecutionEngine(app.Services)).Wait();
        logger.Information("Started Flow Execution Engine");
        
        logger.Information("Strem Initialized");
        app.Run();
        webHost.StopHost();
        logger.Information("Strem Stopped");
    }
}