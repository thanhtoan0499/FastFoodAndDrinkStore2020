using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _service;
        private readonly IPromotionService _servicePromotion;

        public CreateModel(IProductService service, IPromotionService servicePromotion)
        {
            _service = service;
            _servicePromotion = servicePromotion;
        }

        public IActionResult OnGet()
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            Promotions = new SelectList(_servicePromotion.GetListPromotions());
            return Page();
        }

        [BindProperty]
        public SaveProductDto Product { get; set; }
        public SelectList Promotions { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _service.CreateProduct(Product);

            return RedirectToPage("Index");
        }
    }
}
