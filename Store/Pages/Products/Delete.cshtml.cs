using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _service;

        public DeleteModel(IProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public ProductDto Product { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            Product = _service.GetProduct(id ?? default(int));

            if (Product == null)
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

            _service.DeleteProduct(id ?? default(int));

            return RedirectToPage("./Index");
        }
    }
}
