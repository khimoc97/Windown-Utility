using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using WindowUtility.Core.Models;
using WindowUtility.Core.Providers;

namespace WindowUtility.Core.ViewModels
{
    public partial class ViewModelBase : ObservableValidator
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasError))]
        private string _error;

        protected void SetBusy(bool busy = true) => IsBusy = busy;

        protected void SetError(string error = null) => Error = error;

        public bool HasError => !string.IsNullOrWhiteSpace(Error);

        private readonly IApplicationStateProvider _applicationStateProvider;

        public ViewModelBase(IApplicationStateProvider applicationStateProvider)
        {
            this._applicationStateProvider = applicationStateProvider;
        }
    }
}
