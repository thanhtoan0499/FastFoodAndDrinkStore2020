using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Staffs
{
    public class EditModel : PageModel
    {
        private readonly IStaffService _service;
        private readonly IMapper _mapper;

        public EditModel(IStaffService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SaveStaffDto Staff { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            var pStaff = _service.GetStaff(id ?? default(int));

            if (pStaff == null)
            {
                return NotFound();
            }

            Staff = _mapper.Map<StaffDto, SaveStaffDto>(pStaff);

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
                _service.UpdateStaff(Staff);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(Staff.id))
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
        private bool StaffExists(int id)
        {
            return _service.GetStaff(id) != null;
        }

    }
}
