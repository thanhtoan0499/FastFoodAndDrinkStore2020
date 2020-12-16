using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IAccountIndexVmService _productService;
        public IndexModel(IAccountIndexVmService productService)
        {
            _productService = productService;
        }

        public AccountIndexVm AccountIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("Login");
            if(t == "false") return RedirectToPage("Login");
            var permiss = Request.Cookies["permission"];
            if(permiss != null)
            {
                if(!string.IsNullOrEmpty(permiss))
                {
                    if(permiss != "0") return RedirectToPage("../Index");
                }
            }    
            AccountIndexVm = _productService.GetAccountListVm(pageIndex);
            return Page();
        }
    }
}