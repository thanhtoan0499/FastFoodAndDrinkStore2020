using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Receipts
{
    public class DeleteModel : PageModel
    {
        private readonly IReceiptService _service;
        public DeleteModel(IReceiptService service)
        {
            _service = service;
        }

        [BindProperty]
        public ReceiptDto Receipt { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            Receipt = _service.GetReceipt(id ?? default(int));

            if (Receipt == null)
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

            _service.DeleteReceipt(id ?? default(int));
            return RedirectToPage("./Index");
        }
    }
}
