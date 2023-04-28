using System.Windows.Controls;
using WindowUtility.Core.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace WindowUtility.Views.Pages
{
    /// <summary>
    /// Interaction logic for ChangeDefaultGatewayPage.xaml
    /// </summary>
    public partial class ChangeDefaultGatewayPage : INavigableView<ChangeDefaultGatewayViewModel>
    {
        public ChangeDefaultGatewayViewModel ViewModel { get; }

        public ChangeDefaultGatewayPage(ChangeDefaultGatewayViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
