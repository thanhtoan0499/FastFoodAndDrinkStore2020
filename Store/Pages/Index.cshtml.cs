using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Store.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("/Accounts/Login");
            if(t == "false") return RedirectToPage("/Accounts/Login");
            return Page();
        }
        public IActionResult OnPost()
        {
            Response.Cookies.Append("logon", "false");
            Response.Cookies.Append("permission","");
            return RedirectToPage("./Accounts/Login");
        }
    }
}
