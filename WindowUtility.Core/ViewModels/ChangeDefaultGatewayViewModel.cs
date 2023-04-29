using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WindowUtility.Core.Extensions;
using WindowUtility.Core.Models;
using WindowUtility.Core.Providers;
using WindowUtility.Core.Services;

namespace WindowUtility.Core.ViewModels
{
    public partial class ChangeDefaultGatewayViewModel : ViewModelBase
    {
        private readonly IOptions<AppSettings> _options;
        private readonly INetworkAdapterService _networkAdapterService;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(InitCommand))]
        private ObservableCollection<GatewayInfo> _gatewayInfos = new();

        [ObservableProperty]
        private GatewayInfo _selectedGatewayInfo = new();

        public ChangeDefaultGatewayViewModel(
            IApplicationStateProvider applicationStateProvider, 
            IOptions<AppSettings> options,
            INetworkAdapterService networkAdapterService) : base(applicationStateProvider)
        {
            _options = options;
            _networkAdapterService = networkAdapterService;
            Trace.WriteLine("");
        }

        [RelayCommand]
        private void Init()
        {
            GatewayInfos = _options.Value.ListGateway.AsObservableCollection();
            _networkAdapterService.GetCurrentNetworkStatistic();
        }
    }
}
