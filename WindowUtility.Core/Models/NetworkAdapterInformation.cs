using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowUtility.Core.Models
{
    public class NetworkAdapterInformation
    {
        public string IpAddress { get; set; }
        public string SubnetMask { get; set; }
        public string DefaultGateway { get; set; }
        public string PreferredDnsServer { get; set; }
        public string AlternativeDnsServer { get; set; }
    }
}
