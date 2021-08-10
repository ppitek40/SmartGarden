using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartGarden.Helpers;
using SmartGarden.Models;
using SmartGarden.Models.Dtos;

namespace SmartGarden.DeviceGateway
{
    public class DiscoveredDevice
    {
        public string IpAddress { get; set; }
        public string HostName { get; set; }
    }
    public class NetworkDiscovery
    {
        readonly List<DiscoveredDevice> _listOfDevices ;
        CountdownEvent _countdown;
        int _upCount = 0;
        readonly object lockObj = new object();
        const bool ResolveNames = true;
        private readonly string _ipBase;


        public NetworkDiscovery(string ipBase = "192.168.0.1")
        {
            _listOfDevices = new List<DiscoveredDevice>();
            var ipAdressSplitted = ipBase.Split('.');
            var ipAdressJoined = string.Join('.', ipAdressSplitted, 0, 3)+'.';
            _ipBase = ipAdressJoined;
        }

        public List<DiscoveredDevice> Discover()
        {
            _countdown = new CountdownEvent(1);
            
            for (int i = 1; i < 255; i++)
            {
                string ip = _ipBase + i.ToString();

                Ping p = new Ping();
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                _countdown.AddCount();
                p.SendAsync(ip, 100, ip);
            }
            _countdown.Signal();
            _countdown.Wait();
            return _listOfDevices;
        }

        void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                if (ResolveNames)
                {
                    string name;
                    try
                    {
                        IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                        name = hostEntry.HostName;
                    }
                    catch (SocketException ex)
                    {
                        name = "?";
                    }
                    _listOfDevices.Add(new DiscoveredDevice{
                        IpAddress = ip,
                        HostName = name
                    });  
                }
                else
                {
                    
                }
                lock (lockObj)
                {
                    _upCount++;
                }
            }
            else if (e.Reply == null)
            {
            }
            _countdown.Signal();
        }
    }

    public class DeviceConnection
    {
        
        
        public List<HealthcheckDto> GetProperDevicesInNetwork()
        {
            
            var networkDiscovery = new NetworkDiscovery(Dns.GetHostAddresses(Dns.GetHostName())[1].ToString());
            var listOfDevices = networkDiscovery.Discover();
            var properDevices = new List<HealthcheckDto>();
            foreach (var device in listOfDevices)
            {
            
                var httpClient = new HttpClient(new HttpClientHandler())
                {
                    BaseAddress = new Uri("http://"+device.IpAddress),
                    Timeout = TimeSpan.FromSeconds(1)
                };

                var deviceGateway = new DeviceRestClient(httpClient);
                
                var response =  deviceGateway.Healthcheck();

                httpClient.Dispose();

                if (response.device != null)
                {
                    properDevices.Add(response);
                }

            }
            
            return properDevices;
        }
    }
}

