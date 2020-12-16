using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierIndexVmService _productService;
        public IndexModel(ISupplierIndexVmService productService)
        {
            _productService = productService;
        }


        [BindProperty(SupportsGet = true)]
        public string name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string id { get; set; }

        public SupplierIndexVm SupplierIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            SupplierIndexVm = _productService.GetSupplierListVm(id, name, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}