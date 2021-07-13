using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RestEase;

namespace SmartGarden.DeviceGateway
{
    public class DeviceRestClient
    {
        private readonly IDeviceApi _deviceApi;

        public DeviceRestClient(string ipAddress)
        {
            _deviceApi = RestClient.For<IDeviceApi>(ipAddress);

        }
    }

    public interface IDeviceApi
    {
        [Get("status")]
        Task<Models.Device> GetDeviceInfoAsync([Path] string id);
    }
}
