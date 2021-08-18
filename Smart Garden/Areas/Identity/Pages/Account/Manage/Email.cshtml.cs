using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace SmartGarden.Areas.Identity.Pages.Account.Manage
{
    public partial class EmailModel : PageModel
    {
       

        private async Task LoadAsync(IdentityUser user)
        {
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            return NotFound();
        }
    }
}
