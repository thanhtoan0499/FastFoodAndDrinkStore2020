using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Store.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _service;

        public CreateModel(IAccountService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
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
            return Page();
        }

        [BindProperty]
        public SaveAccountDto Account { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _service.CreateAccount(Account);

            return RedirectToPage("Index");
        }
    }
}
