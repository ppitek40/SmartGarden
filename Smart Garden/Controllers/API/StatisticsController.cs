using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SmartGarden.Data;
using SmartGarden.DeviceGateway;
using SmartGarden.Helpers;
using SmartGarden.Migrations;
using SmartGarden.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartGarden.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly SmartGardenContext _context;
        private readonly IMapper _mapper;

        public StatisticsController(SmartGardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [AutomaticRetry(Attempts = 0)]
        public async Task<ActionResult> GetStatistics()
        {
            var devices = await _context.Devices.ToListAsync();
            
            foreach (var device in devices)
            {
                var apiClient = new DeviceRestClient(DeviceHelper.MakeUriFromDeviceMdns(device.DeviceMdns));
                var data = apiClient.GetStatus();
                var measurementHistory = _mapper.Map<DeviceDataDto, MeasurementHistory>(data);
                measurementHistory.DeviceId = device.Id;
                measurementHistory.DateTime = DateTime.UtcNow;
                await _context.MeasurementHistories.AddAsync(measurementHistory);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
