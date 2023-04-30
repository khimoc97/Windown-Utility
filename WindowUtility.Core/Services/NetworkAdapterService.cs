using AutoMapper;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;
using WindowUtility.Core.Models;

namespace WindowUtility.Core.Services
{
    [SupportedOSPlatform("windows")]
    public class NetworkAdapterService : INetworkAdapterService
    {
        private readonly IMapper _mapper;

        private ManagementObjectCollection _managementObjectCollection;

        public NetworkAdapterService(IMapper mapper)
        {
            _mapper = mapper;
            _managementObjectCollection = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
        }

        public void ChangeDefaultGateway()
        {
            foreach (var instance in _managementObjectCollection)
            {
                if (!(bool)instance["ipEnabled"]) continue;

                var caption = instance["Caption"];
                string[] ipAddresses = (string[])instance["IPAddress"];
                string[] ipSubnets = (string[])instance["IPSubnet"];
                string[] gateways = (string[])instance["DefaultIPGateway"];
            }
        }

        public NetworkAdapterInformation GetCurrentNetworkStatistic(NetworkInterfaceType? networkType = NetworkInterfaceType.Ethernet)
        {
            NetworkInterface? networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                                                .FirstOrDefault(network => network.NetworkInterfaceType == networkType);
            var adapterProperties = networkInterface?.GetIPProperties();

            return adapterProperties != null ? _mapper.Map<NetworkAdapterInformation>(adapterProperties) : new NetworkAdapterInformation();
        }
    }
}
