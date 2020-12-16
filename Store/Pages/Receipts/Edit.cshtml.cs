using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Receipts
{
    public class EditModel : PageModel
    {
        private readonly IReceiptService _service;
        private readonly IStaffService _serviceStaff;
        private readonly ICustomerService _serviceCustomer;
        private readonly IMapper _mapper;

        public EditModel(IReceiptService service, IMapper mapper, IStaffService serviceStaff, ICustomerService serviceCustomer)
        {
            _mapper = mapper;
            _service = service;
            _serviceStaff = serviceStaff;
            _serviceCustomer = serviceCustomer;
        }

        [BindProperty]
        public SaveReceiptDto Receipt { get; set; }
        public SelectList Staffs { get; set; }
        public SelectList Customers { get; set; }
        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            var pReceipt = _service.GetReceipt(id ?? default(int));

            if (pReceipt == null)
            {
                return NotFound();
            }

            //select list for edit
            Staffs = new SelectList(_serviceStaff.GetListStaffs());
            Customers = new SelectList(_serviceCustomer.GetListCustomers());
            //bind Receipt
            Receipt = _mapper.Map<ReceiptDto, SaveReceiptDto>(pReceipt);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            Receipt.TotalCost = _service.GetReceipt(Receipt.id).TotalCost;
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _service.UpdateReceipt(Receipt);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(Receipt.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }
        private bool ReceiptExists(int id)
        {
            return _service.GetReceipt(id) != null;
        }

    }
}
