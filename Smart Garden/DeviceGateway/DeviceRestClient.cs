using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestEase;
using SmartGarden.Models;
using SmartGarden.Models.Dtos;

namespace SmartGarden.DeviceGateway
{
    public class DeviceRestClient
    {
        private readonly IDeviceApi _deviceApi;

        public DeviceRestClient(string ipAddress)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = { new StringEnumConverter() }
            };
            _deviceApi = new RestClient(ipAddress)
            {
                JsonSerializerSettings = settings

            }.For<IDeviceApi>();

        }
        public DeviceRestClient(HttpClient httpClient)
        {
            _deviceApi = RestClient.For<IDeviceApi>(httpClient);

        }

        public DeviceDataDto GetStatus()
        {
            var response = _deviceApi.GetDeviceInfoAsync().Result;
            return response;
        }

        public HealthcheckDto Healthcheck()
        {
            try
            {
                var response = _deviceApi.HealthCheck().Result;
                
                if (response.ResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    return new HealthcheckDto();
                }

                var content = response.GetContent();
                response.Dispose();
                return content;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return new HealthcheckDto();
            }


        }

        public async Task<HttpResponseMessage> SaveSettings(DeviceSettingsDto deviceSettings)
        {
            var response =  _deviceApi.SaveSettingsToDeviceAsync(deviceSettings).Result;
            return response.ResponseMessage;
        }
    }

    public interface IDeviceApi
    {
        [Get("/healthcheck")]
        [AllowAnyStatusCode]
        Task<Response<HealthcheckDto>> HealthCheck();

        [Get("/data")]
        Task<DeviceDataDto> GetDeviceInfoAsync();

        [Post("/params")]
        Task<Response<ResponseStatus>> SaveSettingsToDeviceAsync([Body] DeviceSettingsDto deviceSettings);
    }

    public class ResponseStatus
    {
        public string status { get; set; }
    }
}
