using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection;
using WindowUtility.Core.Models;
using WindowUtility.Core.Providers;

namespace WindowUtility.Core.ViewModels
{
    public partial class ChangeDefaultGatewayViewModel : ViewModelBase
    {
        private readonly IConfiguration _configuration;

        public ChangeDefaultGatewayViewModel(IApplicationStateProvider applicationStateProvider, IConfiguration configuration) : base(applicationStateProvider)
        {
            _configuration = configuration;
            var result = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
            Trace.WriteLine(result);
        }

    }
}
