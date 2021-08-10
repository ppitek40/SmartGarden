using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;
using SmartGarden.Data;
using SmartGarden.Models;
using SmartGarden.ViewModels;

namespace SmartGarden.Controllers
{
    public class DeviceController : Controller
    {
        private readonly SmartGardenContext _context;
        private readonly IMapper _mapper;

        public DeviceController(SmartGardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: DeviceController
        public ActionResult Index()
        {
            return View("DeviceList");
        }

      
        // GET: DeviceController/Create
        public ActionResult Create()
        {
            

            return View("DeviceCreate");
        }

        

        // GET: DeviceController/Edit/5
        public ActionResult Edit(int id)
        {
            var device = _context.Devices.SingleOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View("DeviceEdit",device);
        }

        // POST: DeviceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Device device)
        {
            if (!ModelState.IsValid)
            {
                return View("DeviceEdit", device);
            }
            
            var deviceInDb = _context.Devices.SingleOrDefault(d => d.Id == device.Id);
            _mapper.Map<Device, Device>(device, deviceInDb);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
