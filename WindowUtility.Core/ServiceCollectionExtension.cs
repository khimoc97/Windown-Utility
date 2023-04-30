using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Versioning;
using WindowUtility.Core.Models;
using WindowUtility.Core.Providers;
using WindowUtility.Core.Services;
using WindowUtility.Core.ViewModels;
using WindowUtility.Core.Mapper;

namespace WindowUtility.Core
{
    [SupportedOSPlatform("windows")]
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IApplicationStateProvider, InMemoryApplicationStateProvider>()
                .AddSingleton<INetworkAdapterService, NetworkAdapterService>()
                // ViewModel
                .AddViewModels()
                .AddAutoMapper(typeof(AutoMapperProfile).Assembly)
                .AddTransient<IMessenger>(sp => WeakReferenceMessenger.Default)
                ;
            ;
        }

        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("WindowUtility"));
            services.Configure<List<GatewayInfo>>(configuration.GetSection("ListGateway"));
            return services;
        }
    }
}
