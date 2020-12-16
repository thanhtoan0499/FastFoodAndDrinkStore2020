using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly ISupplierService _service;

        public DetailsModel(ISupplierService service)
        {
            _service = service;
        }

        public SupplierDto Supplier { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            Supplier = _service.GetSupplier(id ?? default(int));

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
