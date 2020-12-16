using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly IInvoiceService _service;
        private readonly IStaffService _serviceStaff;
        private readonly ISupplierService _serviceSupplier;
        public CreateModel(IInvoiceService service, IStaffService serviceStaff, ISupplierService serviceSupplier)
        {
            _service = service;
            _serviceStaff = serviceStaff;
            _serviceSupplier = serviceSupplier;
        }

        public IActionResult OnGet()
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            Staffs = new SelectList(_serviceStaff.GetListStaffs("str"));
            Suppliers = new SelectList(_serviceSupplier.GetListSuppliers());
            return Page();
        }

        [BindProperty]
        public SaveInvoiceDto Invoice { get; set; }
        public SelectList Staffs { get; set; }
        public SelectList Suppliers { get; set; }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.CreateInvoice(Invoice);

            return RedirectToPage("Index");
        }
    }
}
