using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SmartGarden.Areas.Identity.Pages.Account.Manage
{
    public class GenerateRecoveryCodesModel : PageModel
    {
        
        public async Task<IActionResult> OnGetAsync()
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return NotFound();
        }
    }
}