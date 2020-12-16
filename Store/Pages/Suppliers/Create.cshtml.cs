using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;

namespace Store.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        private readonly ISupplierService _service;

        public CreateModel(ISupplierService service)
        {
            _service = service;

        }

        public IActionResult OnGet()
        {

            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            return Page();
        }
        [BindProperty]
        public SaveSupplierDto Supplier { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _service.CreateSupplier(Supplier);

            return RedirectToPage("Index");
        }
    }
}
