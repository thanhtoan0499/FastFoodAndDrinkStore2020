using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly IInvoiceService _service;
        public DeleteModel(IInvoiceService service)
        {
            _service = service;
        }

        [BindProperty]
        public InvoiceDto Invoice { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            Invoice = _service.GetInvoice(id ?? default(int));

            if (Invoice == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _service.DeleteInvoice(id ?? default(int));
            return RedirectToPage("./Index");
        }
    }
}
