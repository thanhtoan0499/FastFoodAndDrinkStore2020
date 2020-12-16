using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Pages.Receipts
{
    public class CreateModel : PageModel
    {
        private readonly IReceiptService _service;
        private readonly IStaffService _serviceStaff;
        private readonly ICustomerService _serviceCustomer;
        public CreateModel(IReceiptService service, IStaffService serviceStaff, ICustomerService serviceCustomer)
        {
            _service = service;
            _serviceStaff = serviceStaff;
            _serviceCustomer = serviceCustomer;
        }

        public IActionResult OnGet()
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            Staffs = new SelectList(_serviceStaff.GetListStaffs());
            Customers = new SelectList(_serviceCustomer.GetListCustomers());
            return Page();
        }

        [BindProperty]
        public SaveReceiptDto Receipt { get; set; }
        public SelectList Staffs { get; set; }
        public SelectList Customers { get; set; }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.CreateReceipt(Receipt);

            return RedirectToPage("Index");
        }
    }
}
