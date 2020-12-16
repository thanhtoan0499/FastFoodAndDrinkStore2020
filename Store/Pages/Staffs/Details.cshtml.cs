using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Staffs
{
    public class DetailsModel : PageModel
    {
        private readonly IStaffService _service;

        public DetailsModel(IStaffService service)
        {
            _service = service;
        }

        public StaffDto Staff { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            Staff = _service.GetStaff(id ?? default(int));

            if (Staff == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
