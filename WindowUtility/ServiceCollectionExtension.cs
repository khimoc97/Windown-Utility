using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindowUtility.Core;
using WindowUtility.Core.Interactions;
using WindowUtility.Models;
using WindowUtility.Services;
using WindowUtility.UIServices;
using WindowUtility.ViewModels;
using WindowUtility.Views;
using WindowUtility.Views.Pages;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace WindowUtility
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUiServices(this IServiceCollection services, IConfiguration configuration)
        {
            // App Host
            services
                .AddHostedService<ApplicationHostService>()
                // Page resolver service
                .AddSingleton<IPageService, PageService>()
                // Theme manipulation
                .AddSingleton<IThemeService, ThemeService>()
                // TaskBar manipulation
                .AddSingleton<ITaskBarService, TaskBarService>()
                // Service containing navigation, same as INavigationWindow... but without window
                .AddSingleton<INavigationService, NavigationService>()
                // Main window container with navigation
                .AddScoped<INavigationWindow, MainPage>()
                // UI view models
                .AddScoped<MainPageViewModel>()
                .AddScoped<SettingsViewModel>()
                // Pages
                .AddScoped<ChangeDefaultGatewayPage>()
                .AddScoped<SettingsPage>()
                // Service and Core
                .AddCoreServices()
                .AddAppSettings(configuration)
                .AddSingleton<ISnackbarService, SnackbarService>()
                .AddScoped<IToastService, ToastService>();

            // Configuration
            services.Configure<AppConfig>(configuration.GetSection(nameof(AppConfig)));

            return services;
        }
    }
}
