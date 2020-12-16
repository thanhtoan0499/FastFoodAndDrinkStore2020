using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _service;
        public readonly IPromotionService _servicePromotion;
        private readonly IMapper _mapper;

        public EditModel(IProductService service, IMapper mapper, IPromotionService servicePromotion)
        {
            _mapper = mapper;
            _service = service;
            _servicePromotion = servicePromotion;
        }

        [BindProperty]
        public SaveProductDto Product { get; set; }
        public SelectList Promotions { get; set; }
        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            var pProduct = _service.GetProduct(id ?? default(int));

            if (pProduct == null)
            {
                return NotFound();
            }

            Promotions = new SelectList(_servicePromotion.GetListPromotions());
            Product = _mapper.Map<ProductDto, SaveProductDto>(pProduct);

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
                _service.UpdateProduct(Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.id))
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
        private bool ProductExists(int id)
        {
            return _service.GetProduct(id) != null;
        }

    }
}
