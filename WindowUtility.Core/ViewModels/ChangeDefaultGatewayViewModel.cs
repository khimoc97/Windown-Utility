using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using WindowUtility.Core.Models;
using WindowUtility.Core.Providers;
using WindowUtility.Core.Services;

namespace WindowUtility.Core.ViewModels
{
    public partial class ChangeDefaultGatewayViewModel : ViewModelBase
    {
        private readonly IConfiguration _configuration;
        private readonly INetworkAdapterService _networkAdapterService;

        public ChangeDefaultGatewayViewModel(
            IApplicationStateProvider applicationStateProvider, 
            IConfiguration configuration,
            INetworkAdapterService networkAdapterService) : base(applicationStateProvider)
        {
            _configuration = configuration;
            _networkAdapterService = networkAdapterService;
            var options = _configuration.GetValue<List<GatewayInfo>>("ListGateway");
            Trace.WriteLine("");
        }

        [RelayCommand]
        private void ButtonClicked()
        {
            _networkAdapterService.ChangeDefaultGateway();
            Trace.WriteLine($"{nameof(ButtonClicked)}");
        }
    }
}
