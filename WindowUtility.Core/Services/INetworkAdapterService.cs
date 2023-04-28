using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowUtility.Core.Services
{
    public interface INetworkAdapterService
    {
        void GetCurrentNetworkStatistic();
        void ChangeDefaultGateway();
    }
}
