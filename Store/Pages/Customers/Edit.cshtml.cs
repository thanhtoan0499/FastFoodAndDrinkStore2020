using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public EditModel(ICustomerService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SaveCustomerDto Customer { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            var pCustomer = _service.GetCustomer(id ?? default(int));

            if (pCustomer == null)
            {
                return NotFound();
            }

            Customer = _mapper.Map<CustomerDto, SaveCustomerDto>(pCustomer);

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
                _service.UpdateCustomer(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.id))
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
        private bool CustomerExists(int id)
        {
            return _service.GetCustomer(id) != null;
        }

    }
}
