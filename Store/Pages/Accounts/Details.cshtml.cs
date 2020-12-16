using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _service;

        public DetailsModel(IAccountService service)
        {
            _service = service;
        }

        public AccountDto Account { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("Login");
            if(t == "false") return RedirectToPage("Login");

            var permiss = Request.Cookies["permission"];
            if(permiss != null)
            {
                if(!string.IsNullOrEmpty(permiss))
                {
                    if(permiss != "0") return RedirectToPage("../Index");
                }
            }
            if (id == null)
            {
                return NotFound();
            }

            Account = _service.GetAccount(id ?? default(int));

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
