using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using SmartGarden.Data;
using SmartGarden.DeviceGateway;
using SmartGarden.Models;
using SmartGarden.Models.Dtos;

namespace SmartGarden.Helpers
{
    public class DeviceHelper
    {
        private readonly string _mdns;
        private readonly IMapper _mapper;
        private readonly DeviceRestClient _deviceRestClient;
        public DeviceHelper(string mdns,IMapper mapper)
        {
            _mdns = mdns;
            _mapper = mapper;
            _deviceRestClient = new DeviceRestClient(MakeUriFromDeviceMdns(mdns));
        }

        public async Task AddPlanToDevice(CultivationPlan cultivationPlan)
        {
            var settings = new DeviceSettingsDto();
            _mapper.Map<CultivationPlan, DeviceSettingsDto>(cultivationPlan, settings);

            var response = await _deviceRestClient.SaveSettings(settings);

        }

        public static string MakeUriFromDeviceMdns(string mdns)
        {
            return "http://"+mdns+".local";
        }

        public static void GettingStatisticsFromDevices(SmartGardenContext context, IMapper mapper)
        {
            var devices = context.Devices.ToList();

            foreach (var device in devices)
            {
                var apiClient = new DeviceRestClient(DeviceHelper.MakeUriFromDeviceMdns(device.DeviceMdns));
                var data = apiClient.GetStatus();
                var measurementHistory = mapper.Map<DeviceDataDto, MeasurementHistory>(data);
                measurementHistory.DeviceId = device.Id;
                measurementHistory.DateTime = DateTime.UtcNow;
                context.MeasurementHistories.Add(measurementHistory);
            }
            context.SaveChanges();
        }
    }
}
