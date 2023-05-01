using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;
using WindowUtility.Core.Extensions;
using WindowUtility.Core.Interactions;
using WindowUtility.Core.Models;
using WindowUtility.Core.Providers;
using WindowUtility.Core.Services;

namespace WindowUtility.Core.ViewModels
{
    public partial class ChangeDefaultGatewayViewModel : ViewModelBase
    {
        private readonly IOptions<AppSettings> _options;
        private readonly INetworkAdapterService _networkAdapterService;
        private readonly IToastService _toastService;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(InitCommand))]
        private ObservableCollection<GatewayInfo> _gatewayInfos = new();

        [ObservableProperty]
        private GatewayInfo _selectedGatewayInfo = new();

        [ObservableProperty]
        private NetworkAdapterInformation _networkAdapterInformation = new();

        public ChangeDefaultGatewayViewModel(
            IApplicationStateProvider applicationStateProvider, 
            IOptions<AppSettings> options,
            INetworkAdapterService networkAdapterService,
            IToastService toastService) : base(applicationStateProvider)
        {
            _options = options;
            _networkAdapterService = networkAdapterService;
            _toastService = toastService;
        }

        [RelayCommand]
        private void Init()
        {
            GatewayInfos = _options.Value.ListGateway.AsObservableCollection();
            NetworkAdapterInformation = _networkAdapterService.GetCurrentNetworkStatistic();
        }

        [RelayCommand]
        private void ChangeNetworkAdapterConfiguration()
        {
            _networkAdapterService.ChangeNetworkConfiguration(NetworkAdapterInformation, SelectedGatewayInfo.DefaultGateway);
            NetworkAdapterInformation = _networkAdapterService.GetCurrentNetworkStatistic();

            _toastService.ShowInformationAsync("Change Default Gateway successfully.");
        }

        [RelayCommand]
        private void AutoObtainIP()
        {
            _networkAdapterService.EnableDHCP();
            NetworkAdapterInformation = _networkAdapterService.GetCurrentNetworkStatistic();
            
            _toastService.ShowInformationAsync("Change to auto obtain IP information successfully.");
        }
    }
}
