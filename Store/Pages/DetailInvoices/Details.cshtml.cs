using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.DetailInvoices
{
    public class DetailsModel : PageModel
    {
        private readonly IInvoiceService _service;

        public DetailsModel(IInvoiceService service)
        {
            _service = service;
        }

        public DetailInvoiceDto DetailInvoice { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            DetailInvoice = _service.GetDetailInvoice(id ?? default(int));

            if (DetailInvoice == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
