using System.Diagnostics;
using System.Management;

namespace WindowUtility.Core.Services
{
    public class NetworkAdapterService : INetworkAdapterService
    {
        public void ChangeDefaultGateway()
        {
            throw new NotImplementedException();
        }

        public void GetCurrentNetworkStatistic()
        {
            GetSystemInfo();
        }

        private void GetSystemInfo()
        {
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var instances = managementClass.GetInstances();

            foreach (var instance in instances)
            {
                if (!(bool)instance["ipEnabled"]) continue;

                string[] ipAddresses = (string[])instance["IPAddress"];
            }
        }
    }
}
