using System.Net.NetworkInformation;
using WindowUtility.Core.Models;

namespace WindowUtility.Core.Services
{
    public interface INetworkAdapterService
    {
        void ChangeDefaultGateway();
        NetworkAdapterInformation GetCurrentNetworkStatistic(NetworkInterfaceType? networkType = NetworkInterfaceType.Ethernet);
    }
}
