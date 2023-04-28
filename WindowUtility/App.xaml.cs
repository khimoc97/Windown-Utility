using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using WindowUtility.Core.Models;
using WindowUtility.Core.Providers;

namespace WindowUtility
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => c
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location))
                .AddJsonFile("appsettings.json", optional: true)
            )
            .ConfigureServices((context, services) =>
            {
                services.AddUiServices(context.Configuration);
            })
            .Build();

        // <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            var windowUtilityOption = GetService<IOptions<AppSettings>>();
            var stateProvider = GetService<IApplicationStateProvider>();
            //stateProvider.PatchState(new Dictionary<string, string>
            //{
            //    { nameof(ApplicationState.Env), tallyOption.Value.Env }
            //});
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
            Debug.WriteLine(e.Exception.Message + e.Exception.StackTrace);
        }
    }
}
