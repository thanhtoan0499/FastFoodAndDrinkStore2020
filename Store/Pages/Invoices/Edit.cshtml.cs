using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly IInvoiceService _service;
        private readonly IStaffService _serviceStaff;
        private readonly ISupplierService _serviceSupplier;
        private readonly IMapper _mapper;

        public EditModel(IInvoiceService service, IMapper mapper, IStaffService serviceStaff, ISupplierService serviceSupplier)
        {
            _mapper = mapper;
            _service = service;
            _serviceStaff = serviceStaff;
            _serviceSupplier = serviceSupplier;
        }

        [BindProperty]
        public SaveInvoiceDto Invoice { get; set; }
        public SelectList Staffs { get; set; }
        public SelectList Suppliers { get; set; }
        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            if (id == null)
            {
                return NotFound();
            }

            var pInvoice = _service.GetInvoice(id ?? default(int));

            if (pInvoice == null)
            {
                return NotFound();
            }

            //select list for edit
            Staffs = new SelectList(_serviceStaff.GetListStaffs("str"));
            Suppliers = new SelectList(_serviceSupplier.GetListSuppliers());
            //bind invoice
            Invoice = _mapper.Map<InvoiceDto, SaveInvoiceDto>(pInvoice);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            Invoice.Cost  = _service.GetInvoice(Invoice.id).Cost;
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _service.UpdateInvoice(Invoice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(Invoice.id))
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
        private bool InvoiceExists(int id)
        {
            return _service.GetInvoice(id) != null;
        }

    }
}
