using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowUtility.Core.ViewModels
{
    public static class ViewModelCollectionExtension
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
           return services
                .AddTransient<ChangeDefaultGatewayViewModel>();
        }
    }
}
