using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowUtility.Core.Interactions
{
    public interface IToastService
    {
        Task ShowAsync(string message, string title, ToastType type);
        Task ShowInformationAsync(string message) => ShowAsync(message, "Information", ToastType.Information);
    }

    public enum ToastType
    {
        Information = 0,
        InformationError = 1,
    }
}
