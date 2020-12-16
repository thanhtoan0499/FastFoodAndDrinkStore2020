using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Suppliers
{
    public class EditModel : PageModel
    {
        private readonly ISupplierService _service;
  
        private readonly IMapper _mapper;

        public EditModel(ISupplierService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
   
        }

        [BindProperty]
        public SaveSupplierDto Supplier { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }
            var pSupplier = _service.GetSupplier(id ?? default(int));

            if (pSupplier == null)
            {
                return NotFound();
            }

            Supplier = _mapper.Map<SupplierDto, SaveSupplierDto>(pSupplier);
            
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _service.UpdateSupplier(Supplier);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(Supplier.id))
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
        private bool SupplierExists(int id)
        {
            return _service.GetSupplier(id) != null;
        }

    }
}
