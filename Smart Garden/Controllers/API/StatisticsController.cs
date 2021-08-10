using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGarden.Data;
using SmartGarden.DeviceGateway;
using SmartGarden.Migrations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartGarden.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly SmartGardenContext _context;

        public StatisticsController(SmartGardenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<int> Test()
        {
            
            return 1;
        }
       

        [HttpPost]
        public async Task<ActionResult> GetStatistics(int id)
        {
            var devices = await _context.Devices.ToListAsync();
            //ip = "192.168.0.26/";
            foreach (var device in devices)
            {
                var apiClient = new DeviceRestClient(device.DeviceMdns.ToString());
                var data = apiClient.GetStatus();
            }
            return Ok();
        }
    }
}
