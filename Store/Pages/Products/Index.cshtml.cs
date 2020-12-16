using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductIndexVmService _productService;
        public IndexModel(IProductIndexVmService productService)
        {
            _productService = productService;
        }


        [BindProperty(SupportsGet = true)]
        public string searchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchType { get; set; }

        [BindProperty(SupportsGet = true)]
        public int searchPriceFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public int searchPriceTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int searchQuantityFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public int searchQuantityTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchCode { get; set; }

        public ProductIndexVm ProductIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            ProductIndexVm = _productService.GetProductListVm(searchCode, searchName, searchType, searchPriceFrom, searchPriceTo, searchQuantityFrom, searchQuantityTo, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}