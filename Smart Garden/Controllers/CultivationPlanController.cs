using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartGarden.Data;

namespace SmartGarden.Controllers
{
    public class CultivationPlanController : Controller
    {
        private readonly SmartGardenContext _context;

        public CultivationPlanController(SmartGardenContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("CultivationPlanList");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("CultivationPlanForm");
        }
        
    }
}
