using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.DetailReceipts
{
    public class DetailsModel : PageModel
    {
        private readonly IReceiptService _service;

        public DetailsModel(IReceiptService service)
        {
            _service = service;
        }

        public DetailReceiptDto DetailReceipt { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            DetailReceipt = _service.GetDetailReceipt(id ?? default(int));

            if (DetailReceipt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
