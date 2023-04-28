using System;
using System.Windows;
using System.Windows.Controls;
using WindowUtility.ViewModels;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace WindowUtility.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : INavigationWindow
    {
        public MainPageViewModel ViewModel { get; }

        public MainPage(
            MainPageViewModel viewModel,
            IPageService pageService,
            INavigationService navigationService,
            ISnackbarService snackbarService)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
            SetPageService(pageService);

            snackbarService.SetSnackbarControl(RootSnackbar);
            navigationService.SetNavigationControl(RootNavigation);
        }

        public Frame GetFrame() => RootFrame;

        public INavigation GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService) => RootNavigation.PageService = pageService;

        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
