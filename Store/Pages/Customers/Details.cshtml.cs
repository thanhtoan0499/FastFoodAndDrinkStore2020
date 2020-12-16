using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerService _service;

        public DetailsModel(ICustomerService service)
        {
            _service = service;
        }

        public CustomerDto Customer { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            Customer = _service.GetCustomer(id ?? default(int));

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
