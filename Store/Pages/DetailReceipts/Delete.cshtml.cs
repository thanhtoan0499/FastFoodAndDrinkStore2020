using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using ApplicationCore.Mapping;
namespace Store.Pages.DetailReceipts
{
    public class DeleteModel : PageModel
    {
        private readonly IReceiptService _service;
        private readonly IProductService _serviceProduct;
        private readonly IMapper _mapper;
        public DeleteModel(IReceiptService service, IProductService serviceProduct,IMapper mapper)
        {
            _service = service;
            _serviceProduct = serviceProduct;
            _mapper = mapper;
        }

        [BindProperty]
        public DetailReceiptDto DetailReceipt { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            DetailReceipt = _service.GetDetailReceipt(id ?? default(int));

            if (DetailReceipt == null)
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

            var detailReceipt = _service.GetDetailReceipt(id ?? default(int));
            _service.DeleteDetailReceipt(id ?? default(int));
            //_service.UpdateCostReceipt(detailReceipt.ReceiptId, _service.GetTotalCost(detailReceipt.ReceiptId));
            var t = _serviceProduct.GetProduct(detailReceipt.ProductID);
            t.Quantity = t.Quantity - detailReceipt.Quantity;
            _serviceProduct.UpdateProduct(_mapper.Map<ProductDto,SaveProductDto>(t));
            Response.Cookies.Append("receiptID", detailReceipt.ReceiptID.ToString());
            Response.Cookies.Append("timeCheck", "true");
            return RedirectToPage("./Index");
        }
    }
}
