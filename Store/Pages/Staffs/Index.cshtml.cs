using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;

namespace Store.Pages.Staffs
{
    public class IndexModel : PageModel
    {
        private readonly IStaffIndexVmService _staffService;
        public IndexModel(IStaffIndexVmService staffService)
        {
            _staffService = staffService;
        }

        [BindProperty(SupportsGet = true)]
        public string lastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string firstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string gender { get; set; }

        [BindProperty(SupportsGet = true)]
        public string position { get; set; }

        [BindProperty(SupportsGet = true)]
        public string code { get; set; }
        
        public StaffIndexVm StaffIndexVm { get; set; }

        public IActionResult OnGet(int pageIndex = 1)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");

            StaffIndexVm = _staffService.GetStaffListVm(code, lastName, firstName, gender, position, pageIndex);
            return Page();
        }
        public IActionResult Back()
        {
            return RedirectToPage("Index");
        }
    }
}