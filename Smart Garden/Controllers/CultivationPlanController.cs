using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using SmartGarden.Data;
using SmartGarden.Models;

namespace SmartGarden.Controllers
{
    [Authorize]
    public class CultivationPlanController : Controller
    {
        private readonly SmartGardenContext _context;
        private readonly IMapper _mapper;

        public CultivationPlanController(SmartGardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cultivationPlan = _context.CultivationPlans.SingleOrDefault(c => c.Id == id);
            if (cultivationPlan == null)
            {
                return NotFound();
            }

            return View("CultivationPlanForm",cultivationPlan);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CultivationPlan cultivationPlan)
        {
            if (!ModelState.IsValid)
            {
                return View("CultivationPlanForm",cultivationPlan);
            }

            _context.CultivationPlans.Add(cultivationPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CultivationPlan cultivationPlan)
        {
            var cultivationPlanInDb = _context.CultivationPlans.SingleOrDefault(c => c.Id == cultivationPlan.Id);
            if (cultivationPlanInDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("CultivationPlanForm", cultivationPlan);
            }

            _mapper.Map<CultivationPlan,CultivationPlan>(cultivationPlan,cultivationPlanInDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
