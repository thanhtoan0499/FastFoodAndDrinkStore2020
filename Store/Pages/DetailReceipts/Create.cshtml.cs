using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
namespace Store.Pages.DetailReceipts
{
    public class CreateModel : PageModel
    {
        private readonly IReceiptService _service;
        private readonly IProductService _serviceProduct;
        private readonly IMapper _mapper;

        public CreateModel(IMapper mapper,IReceiptService service, IProductService serviceProduct)
        {
            _mapper = mapper;
            _service = service;
            _serviceProduct = serviceProduct;
        }

        public IActionResult OnGet(int receiptID)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (receiptID != 0)
            {
                DetailReceipt = new SaveDetailReceiptDto();
                DetailReceipt.ReceiptID = receiptID;
            }
            ViewData["receiptId"] = receiptID;

            Receipts = new SelectList(_service.GetListReceipts());
            Products = new SelectList(_serviceProduct.GetListProducts());
            return Page();
        }

        [BindProperty]
        public SaveDetailReceiptDto DetailReceipt { get; set; }
        public SelectList Receipts { get; set; }
        public SelectList Products { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var t = _serviceProduct.GetProduct(DetailReceipt.ProductID);
            t.Quantity = t.Quantity + DetailReceipt.Quantity;
            DetailReceipt.Cost = t.Price * DetailReceipt.Quantity;

            _service.CreateDetailReceipt(DetailReceipt);
           // _serviceReceipt.UpdateCostReceipt(DetailReceipt.ReceiptId, _service.GetTotalCost(DetailReceipt.ReceiptId));
            _serviceProduct.UpdateProduct(_mapper.Map<ProductDto,SaveProductDto>(t));
            
            Response.Cookies.Append("receiptID", DetailReceipt.ReceiptID.ToString());
            Response.Cookies.Append("timeCheck", "true");
            return RedirectToPage("Index");

        }
    }
}
