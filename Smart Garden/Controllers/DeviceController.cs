using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;
using SmartGarden.Data;
using SmartGarden.Models;
using SmartGarden.ViewModels;

namespace SmartGarden.Controllers
{
    public class DeviceController : Controller
    {
        private readonly SmartGardenContext _context;

        public DeviceController(SmartGardenContext context)
        {
            _context = context;
        }
        // GET: DeviceController
        public ActionResult Index()
        {
            return View("DeviceList");
        }

      
        // GET: DeviceController/Create
        public ActionResult Create()
        {
            return View("DeviceForm");
        }

        // POST: DeviceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Device device)
        {
            if (!ModelState.IsValid)
            {
                
                return View("DeviceForm");
            }

            _context.Devices.Add(device);
            return RedirectToAction(nameof(Index));
        }

        // GET: DeviceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeviceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Device device)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeviceList");
            }
        }

        // POST: DeviceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
