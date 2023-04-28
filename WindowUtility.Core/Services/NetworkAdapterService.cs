using System.Diagnostics;
using System.Management;

namespace WindowUtility.Core.Services
{
    public class NetworkAdapterService : INetworkAdapterService
    {
        public void ChangeDefaultGateway()
        {
            GetSystemInfo();
        }

        public void GetCurrentNetworkStatistic()
        {
            throw new NotImplementedException();
        }

        private void GetSystemInfo()
        {
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var instances = managementClass.GetInstances();

            foreach ( var instance in instances)
            {
                Trace.WriteLine(instance["ipEnabled"]);
            }
        }
    }
}
