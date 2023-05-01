using AutoMapper;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;
using WindowUtility.Core.Models;

namespace WindowUtility.Core.Services
{
    [SupportedOSPlatform("windows")]
    public class NetworkAdapterService : INetworkAdapterService
    {
        private readonly IMapper _mapper;

        private ManagementObject _currentEnableNetworkAdapter;

        public NetworkAdapterService(IMapper mapper)
        {
            _mapper = mapper;
            GetCurrentEnableNetwork();
        }

        public void ChangeNetworkConfiguration(NetworkAdapterInformation currentNetworkConfig, string newDefaultGateway)
        {
            try
            {
                ManagementBaseObject newIP = _currentEnableNetworkAdapter.GetMethodParameters("EnableStatic");
                ManagementBaseObject newGate = _currentEnableNetworkAdapter.GetMethodParameters("SetGateways");
                ManagementBaseObject newDNS = _currentEnableNetworkAdapter.GetMethodParameters("SetDNSServerSearchOrder");

                newIP["IPAddress"] = new string[] { currentNetworkConfig.IpAddress };
                newIP["SubnetMask"] = new string[] { currentNetworkConfig.SubnetMask };

                newGate["DefaultIPGateway"] = new string[] { newDefaultGateway };
                newGate["GatewayCostMetric"] = new int[] { 1 };


                newDNS["DNSServerSearchOrder"] = new string[] { currentNetworkConfig.PreferredDnsServer, currentNetworkConfig.AlternativeDnsServer };

                _ = _currentEnableNetworkAdapter.InvokeMethod("EnableStatic", newIP, null);
                _ = _currentEnableNetworkAdapter.InvokeMethod("SetGateways", newGate, null);
                _ = _currentEnableNetworkAdapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        public void EnableDHCP()
        {
            ManagementBaseObject newDNS = _currentEnableNetworkAdapter.GetMethodParameters("SetDNSServerSearchOrder");
            newDNS["DNSServerSearchOrder"] = null;

            _ = _currentEnableNetworkAdapter.InvokeMethod("EnableDHCP", null, null);
            _ = _currentEnableNetworkAdapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
        }

        public NetworkAdapterInformation GetCurrentNetworkStatistic(NetworkInterfaceType? networkType = NetworkInterfaceType.Ethernet)
        {
            NetworkInterface? networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                                                .FirstOrDefault(network => network.NetworkInterfaceType == networkType);
            var adapterProperties = networkInterface?.GetIPProperties();

            return adapterProperties != null ? _mapper.Map<NetworkAdapterInformation>(adapterProperties) : new NetworkAdapterInformation();
        }

        private void GetCurrentEnableNetwork()
        {
            foreach (ManagementObject instance in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                if ((bool)instance["ipEnabled"])
                {
                    _currentEnableNetworkAdapter = instance;
                }
            }
        }
    }
}
