using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly IInvoiceIndexVmService _invoiceService;
        public IndexModel(IInvoiceIndexVmService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [BindProperty(SupportsGet = true)]
        public string staff { get; set; }

        [BindProperty(SupportsGet = true)]
        public string supplier { get; set; }

        [BindProperty(SupportsGet = true)]
        public int costFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public int costTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public InvoiceIndexVm InvoiceIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            InvoiceIndexVm = _invoiceService.GetInvoiceListVm(staff, supplier, costFrom, costTo, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}