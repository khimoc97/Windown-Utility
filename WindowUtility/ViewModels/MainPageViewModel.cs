using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WindowUtility.Core.Models;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Controls;
using Wpf.Ui.Mvvm.Contracts;
using WindowUtility.Core.Providers;
using WindowUtility.Views.Pages;
using System.Configuration;
using System.Diagnostics;

namespace WindowUtility.ViewModels
{
    public class ToolMessage : ValueChangedMessage<SysMessage>
    {
        public ToolMessage(SysMessage value) : base(value) { }
    }
    public partial class MainPageViewModel : ObservableObject, IRecipient<ToolMessage>
    {
        private readonly INavigationService navigationService;
        private readonly IApplicationStateProvider applicationStateProvider;
        private readonly IMessenger messsenger;
        private bool _isInitialized = false;
        private const string AUTHORIZE_TAG = "AUTHORIZE";

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        [ObservableProperty]
        bool isLoggedIn;

        [ObservableProperty]
        string orgName;

        [ObservableProperty]
        string username;

        public MainPageViewModel(
            INavigationService navigationService,
            IApplicationStateProvider applicationStateProvider,
            IMessenger messsenger)
        {
            if (!_isInitialized)
                InitializeViewModel();
            this.navigationService = navigationService;
            this.applicationStateProvider = applicationStateProvider;
            this.messsenger = messsenger;

            this.messsenger.Register(this);
        }

        private static string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? String.Empty;
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "Window Utility " + GetAssemblyVersion();

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem
                {
                    Content = "Change Default Gateway",
                    PageTag = nameof(ChangeDefaultGatewayPage),
                    Icon = SymbolRegular.NetworkCheck24,
                    PageType = typeof(ChangeDefaultGatewayPage),
                    IsActive = true,
                }
            };

            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Settings",
                    PageTag = nameof(SettingsPage),
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "Home",
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }

        public void Receive(ToolMessage message)
        {

        }

        [RelayCommand]
        private async Task InitAsync()
        {
            //var org = await contextService.GetLastAccessOrgAsync();
            //OrgName = org.Name;

            //applicationStateProvider.PatchState(new()
            //{
            //    { nameof(ApplicationState.OrgId), org.Id.ToString() },
            //    { nameof(ApplicationState.OrgName), org.Name },
            //    { nameof(ApplicationState.DatabaseName), org.DatabaseName },
            //});


            await Task.CompletedTask;
        }
    }
}
