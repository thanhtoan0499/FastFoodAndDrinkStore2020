using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.DetailReceipts
{
    public class IndexModel : PageModel
    {
        private readonly IDetailReceiptIndexVmService _service;
        public IndexModel(IDetailReceiptIndexVmService service)
        {
            _service = service;
        }


        [BindProperty(SupportsGet = true)]
        public int receiptID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int product { get; set; }

        [BindProperty(SupportsGet = true)]
        public int quantityFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public int quantityTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int costFrom { get; set; }
        [BindProperty(SupportsGet = true)]
        public int costTo { get; set; }

        public DetailReceiptIndexVm DetailReceiptIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            var cookieValue = Request.Cookies["receiptID"];
            var timeCheck = Request.Cookies["timeCheck"];
            if (cookieValue != null && timeCheck != null)
                if (timeCheck.Equals("true"))
                {
                    receiptID = int.Parse(cookieValue);
                    Response.Cookies.Append("timeCheck", "false");
                }
            DetailReceiptIndexVm = _service.GetDetailReceiptListVm(receiptID, product, quantityFrom, quantityTo, costFrom, costTo, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}