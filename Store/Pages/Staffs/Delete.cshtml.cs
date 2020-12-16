using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Staffs
{
    public class DeleteModel : PageModel
    {
        private readonly IStaffService _service;

        public DeleteModel(IStaffService service)
        {
            _service = service;
        }

        [BindProperty]
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _service.DeleteStaff(id ?? default(int));

            return RedirectToPage("./Index");
        }
    }
}
