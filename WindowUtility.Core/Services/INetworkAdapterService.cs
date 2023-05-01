using System.Net.NetworkInformation;
using WindowUtility.Core.Models;

namespace WindowUtility.Core.Services
{
    public interface INetworkAdapterService
    {
        void ChangeNetworkConfiguration(NetworkAdapterInformation currentNetworkConfig, string newDefaultGateway);
        NetworkAdapterInformation GetCurrentNetworkStatistic(NetworkInterfaceType? networkType = NetworkInterfaceType.Ethernet);
        void EnableDHCP();
    }
}
