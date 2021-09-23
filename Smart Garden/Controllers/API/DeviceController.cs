using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using RestEase;
using SmartGarden.Data;
using SmartGarden.DeviceGateway;
using SmartGarden.Helpers;
using SmartGarden.Models;
using SmartGarden.Models.Dtos;

namespace SmartGarden.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly SmartGardenContext _context;
        private readonly IMapper _mapper;

        public DeviceController(SmartGardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            var devices = await _context.Devices.Include(d=>d.CultivationPlan).ToListAsync();

            return devices;
        }


        [HttpPost("{mdnsDomain}")]
        public async Task<ActionResult> AddDevice([Query]string mdnsDomain)
        {
            if (await _context.Devices.AnyAsync(d => d.DeviceMdns == mdnsDomain))
            {
                return Conflict();
            }

            var deviceRestClient = new DeviceRestClient(DeviceHelper.MakeUriFromDeviceMdns(mdnsDomain));
            var response = deviceRestClient.Healthcheck();
            if (response.mdnsDomain == null)
            {
                return BadRequest();
            }
            var device = new Device
            {
                DeviceMdns = response.mdnsDomain,
                Name = response.device,
                Version = response.version
            };
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();


            return Created(new Uri(Request.GetDisplayUrl() + "/" + device.Id), device);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.SingleOrDefaultAsync(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Remove(device);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search()
        {
            var deviceConnection = new DeviceConnection();
            var listOfFoundDevices = deviceConnection.GetProperDevicesInNetwork();
            var listOfDevicesInDb = await _context.Devices.ToListAsync();
            var newDevices = listOfFoundDevices.Where(d => !listOfDevicesInDb.Any(d2 => d2.DeviceMdns == d.mdnsDomain));
            return Ok(newDevices);
        }

        [HttpPatch("{deviceId}/{cultivationPlanId}")]
        public async Task<IActionResult> AddCultivationPlanToDevice(int deviceId, int cultivationPlanId)
        {
            var device = await _context.Devices.SingleOrDefaultAsync(d => d.Id == deviceId);
            if (device == null)
            {
                return NotFound();
            }

            var cultivationPlan = await _context.CultivationPlans.SingleOrDefaultAsync(c => c.Id == cultivationPlanId);
            if (cultivationPlan == null)
            {
                return NotFound();
            }

            var deviceHelper = new DeviceHelper(device.DeviceMdns,_mapper);
            await deviceHelper.AddPlanToDevice(cultivationPlan);
            device.CultivationPlanId = cultivationPlanId;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
