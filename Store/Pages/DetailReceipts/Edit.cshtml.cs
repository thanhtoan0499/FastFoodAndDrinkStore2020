using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.DetailReceipts
{
    public class EditModel : PageModel
    {
        private readonly IReceiptService _service;
        private readonly IProductService _serviceProduct;
        private readonly IMapper _mapper;

        public EditModel(IMapper mapper, IReceiptService service, IProductService serviceProduct)
        {
            _mapper = mapper;
            _service = service;
            _serviceProduct = serviceProduct;
        }

        [BindProperty]
        public SaveDetailReceiptDto DetailReceipt { get; set; }

        public SelectList Receipts { get; set; }

        public SelectList Products { get; set; }

        public int TemQuantity {get;set;}

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            var pDetailReceipt = _service.GetDetailReceipt(id ?? default(int));

            if (pDetailReceipt == null)
            {
                return NotFound();
            }

            Receipts = new SelectList(_service.GetListReceipts());
            Products = new SelectList(_serviceProduct.GetListProducts());

            DetailReceipt = _mapper.Map<DetailReceiptDto, SaveDetailReceiptDto>(pDetailReceipt);

            TemQuantity = DetailReceipt.Quantity;
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
               
                var t = _serviceProduct.GetProduct(DetailReceipt.ProductID);
                DetailReceipt.Cost = t.Price * DetailReceipt.Quantity;
                t.Quantity = t.Quantity - TemQuantity + DetailReceipt.Quantity;
                _service.UpdateDetailReceipt(DetailReceipt);
                //update total cost from invoice
                //_serviceReceipt.UpdateCostReceipt(DetailReceipt.ReceiptId, _service.GetTotalCost(DetailReceipt.ReceiptId));
                _serviceProduct.UpdateProduct(_mapper.Map<ProductDto,SaveProductDto>(t));
                Response.Cookies.Append("receiptID", DetailReceipt.ReceiptID.ToString());
                Response.Cookies.Append("timeCheck", "true");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailReceiptExists(DetailReceipt.id))
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
        private bool DetailReceiptExists(int id)
        {
            return _service.GetDetailReceipt(id) != null;
        }
    }
}
