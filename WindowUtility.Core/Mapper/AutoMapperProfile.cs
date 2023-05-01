using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WindowUtility.Core.Models;
using System.Net.Sockets;

namespace WindowUtility.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IPInterfaceProperties, NetworkAdapterInformation>()
                .ForMember(nai => nai.IpAddress, nai => nai.MapFrom(iip => iip.UnicastAddresses.First(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork).Address.ToString()))
                .ForMember(nai => nai.SubnetMask, nai => nai.MapFrom(iip => iip.UnicastAddresses.First(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork).IPv4Mask.ToString()))
                .ForMember(nai=>nai.DefaultGateway, nai=>nai.MapFrom(iip=>iip.GatewayAddresses.First().Address.ToString()))
                .ForMember(nai=>nai.PreferredDnsServer,nai=>nai.MapFrom(iip=>iip.DnsAddresses.First()))
                .ForMember(nai => nai.AlternativeDnsServer, nai => nai.MapFrom(iip=>iip.DnsAddresses.Skip(1).First()));
        }
    }
}
