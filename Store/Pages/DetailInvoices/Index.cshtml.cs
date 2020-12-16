using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.DetailInvoices
{
    public class IndexModel : PageModel
    {
        private readonly IDetailInvoiceIndexVmService _productService;
        public IndexModel(IDetailInvoiceIndexVmService productService)
        {
            _productService = productService;
        }


        [BindProperty(SupportsGet = true)]
        public int invoiceId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string productName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int quantityFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public int quantityTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int costFrom { get; set; }
        [BindProperty(SupportsGet = true)]
        public int costTo { get; set; }

        public DetailInvoiceIndexVm DetailInvoiceIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            var cookieValue = Request.Cookies["invoiceId"];
            var timeCheck = Request.Cookies["timeCheck"];
            if (cookieValue != null && timeCheck != null)
                if (timeCheck.Equals("true"))
                {
                    invoiceId = int.Parse(cookieValue);
                    Response.Cookies.Append("timeCheck", "false");
                }
            DetailInvoiceIndexVm = _productService.GetDetailInvoiceListVm(invoiceId, productName, quantityFrom, quantityTo, costFrom, costTo, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}