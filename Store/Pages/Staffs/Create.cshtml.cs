using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Store.Pages.Staffs
{
    public class CreateModel : PageModel
    {
        private readonly IStaffService _service;

        public CreateModel(IStaffService service)
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
        public SaveStaffDto Staff { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.CreateStaff(Staff);

            return RedirectToPage("Index");
        }
    }
}
