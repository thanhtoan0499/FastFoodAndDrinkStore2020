using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Promotions
{
    public class DeleteModel : PageModel
    {
        private readonly IPromotionService _service;

        public DeleteModel(IPromotionService service)
        {
            _service = service;
        }

        [BindProperty]
        public PromotionDto Promotion { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            Promotion = _service.GetPromotion(id ?? default(int));

            if (Promotion == null)
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

            _service.DeletePromotion(id ?? default(int));

            return RedirectToPage("./Index");
        }
    }
}
