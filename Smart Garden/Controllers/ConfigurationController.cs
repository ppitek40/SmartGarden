using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using SmartGarden.Areas.Identity.Pages.Account;
using SmartGarden.Data;
using SmartGarden.ViewModels;

namespace SmartGarden.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly SmartGardenContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public ConfigurationController(
            SmartGardenContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        public IActionResult Index()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(model.Login);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
