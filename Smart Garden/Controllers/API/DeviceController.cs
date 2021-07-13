using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGarden.Data;
using SmartGarden.Models;

namespace SmartGarden.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly SmartGardenContext _context;

        public DeviceController(SmartGardenContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            var devices = await _context.Devices.ToListAsync();

            return devices;
        }


    }
}
