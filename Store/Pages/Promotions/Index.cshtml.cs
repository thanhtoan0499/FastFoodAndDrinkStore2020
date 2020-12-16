using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.Promotions
{
    public class IndexModel : PageModel
    {
        private readonly IPromotionIndexVmService _productService;
        public IndexModel(IPromotionIndexVmService productService)
        {
            _productService = productService;
        }


        [BindProperty(SupportsGet = true)]
        public string name { get; set; }
        [BindProperty(SupportsGet = true)]
        public int discountFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public int discountTo { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime start { get; set; }
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime end { get; set; }

        public PromotionIndexVm PromotionIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            PromotionIndexVm = _productService.GetPromotionListVm(name, discountFrom, discountTo, start, end, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}