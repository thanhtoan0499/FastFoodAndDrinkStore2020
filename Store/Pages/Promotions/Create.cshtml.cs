using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Store.Pages.Promotions
{
    public class CreateModel : PageModel
    {
        private readonly IPromotionService _service;

        public CreateModel(IPromotionService service)
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
        public SavePromotionDto Promotion { get; set; }

        public string ValidForCodeName { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var existPromotion = _service.GetProByCode(Promotion.Name);
            if (existPromotion != null)
            {
                ValidForCodeName = "Name code already exists.";
                return Page();
            }
            else
            {
                ValidForCodeName = "";
            }

            _service.CreatePromotion(Promotion);

            return RedirectToPage("Index");
        }
    }
}
