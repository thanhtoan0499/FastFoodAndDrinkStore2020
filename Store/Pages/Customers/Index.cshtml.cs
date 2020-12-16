using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Infrastructure.Persistence;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerIndexVmService _productService;
        public IndexModel(ICustomerIndexVmService productService)
        {
            _productService = productService;
        }


        [BindProperty(SupportsGet = true)]
    public string name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string gender { get; set; }

        [BindProperty(SupportsGet = true)]
        public string phone { get; set; }

        [BindProperty(SupportsGet = true)]
        public string code { get; set; }

        public CustomerIndexVm CustomerIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            CustomerIndexVm = _productService.GetCustomerListVm(code, name, gender, phone, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}
