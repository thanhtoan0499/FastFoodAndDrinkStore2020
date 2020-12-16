using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Promotions
{
    public class EditModel : PageModel
    {
        private readonly IPromotionService _service;
        private readonly IMapper _mapper;

        public EditModel(IPromotionService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SavePromotionDto Promotion { get; set; }
        public string ValidForCodeName { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            var pPromotion = _service.GetPromotion(id ?? default(int));

            if (pPromotion == null)
            {
                return NotFound();
            }

            Promotion = _mapper.Map<PromotionDto, SavePromotionDto>(pPromotion);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ValidForCodeName = "";
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

            try
            {
                _service.UpdatePromotion(Promotion);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionExists(Promotion.id))
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
        private bool PromotionExists(int id)
        {
            return _service.GetPromotion(id) != null;
        }

    }
}
