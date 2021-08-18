using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartGarden.Areas.Identity.Pages.Account.Manage
{
    public class ExternalLoginsModel : PageModel
    {
        
        public async Task<IActionResult> OnGetAsync()
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPostRemoveLoginAsync(string loginProvider, string providerKey)
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPostLinkLoginAsync(string provider)
        {
            return NotFound();
        }

        public async Task<IActionResult> OnGetLinkLoginCallbackAsync()
        {
            return NotFound();
        }
    }
}
