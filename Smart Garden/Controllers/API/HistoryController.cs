using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGarden.Data;

namespace SmartGarden.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly SmartGardenContext _context;

        public HistoryController(SmartGardenContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> GetHistory()
        {
            var history = await _context.MeasurementHistories.ToListAsync();
            return new JsonResult(history);
    }
    }
}
