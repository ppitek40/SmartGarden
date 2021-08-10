using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGarden.Data;
using SmartGarden.Models;
using SQLitePCL;

namespace SmartGarden.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivationPlanController : ControllerBase
    {
        private readonly SmartGardenContext _context;

        public CultivationPlanController(SmartGardenContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<CultivationPlan>>> GetCultivationPlan()
        {
            var cultivationPlans = await _context.CultivationPlans.ToListAsync();

            return Ok(cultivationPlans);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCultivationPlan(int id)
        {
            var cultivationPlan = _context.CultivationPlans.SingleOrDefault(c => c.Id == id);
            if (cultivationPlan == null)
            {
                return NotFound();
            }

            _context.Remove(cultivationPlan);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
