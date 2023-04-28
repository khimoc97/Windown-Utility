using System;
using System.Threading.Tasks;
using WindowUtility.Core.Interactions;
using Wpf.Ui.Mvvm.Contracts;

namespace WindowUtility.UIServices
{
    public class ToastService : IToastService
    {
        private readonly ISnackbarService _snackbarService;
        public ToastService(ISnackbarService snackbarService)
        {
            _snackbarService = snackbarService;
        }

        public async Task ShowAsync(string message, string title, ToastType type)
        {
            await _snackbarService.ShowAsync(
                title: title,
                message: message,
                icon: Wpf.Ui.Common.SymbolRegular.Info16,
                appearance: type == ToastType.Information ? Wpf.Ui.Common.ControlAppearance.Info : Wpf.Ui.Common.ControlAppearance.Danger);
        }
    }
}
