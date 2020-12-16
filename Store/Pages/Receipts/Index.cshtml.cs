using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;
using System;
namespace Store.Pages.Receipts
{
    public class IndexModel : PageModel
    {
        private readonly IReceiptIndexVmService _service;
        public IndexModel(IReceiptIndexVmService service)
        {
            _service = service;
        }
        
        [BindProperty(SupportsGet = true)]
        public int receiptID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int staff { get; set; }

        [BindProperty(SupportsGet = true)]
        public int customer { get; set; }

        [BindProperty(SupportsGet = true)]
        public int costFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public int costTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime start { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime end { get; set; }

        [BindProperty(SupportsGet = true)]
        public ReceiptIndexVm ReceiptIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            ReceiptIndexVm = _service.GetReceiptListVm(receiptID, staff, customer,start,end, costFrom, costTo, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}