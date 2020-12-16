using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
namespace Store.Pages.DetailInvoices
{
    public class CreateModel : PageModel
    {
        private readonly IInvoiceService _service;
        private readonly IProductService _serviceProduct;
        private readonly IMapper _mapper;

        public CreateModel(IMapper mapper,IInvoiceService service, IProductService serviceProduct)
        {
            _mapper = mapper;
            _service = service;
            _serviceProduct = serviceProduct;
        }

        public IActionResult OnGet(int invoiceId)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (invoiceId != 0)
            {
                DetailInvoice = new SaveDetailInvoiceDto();
                DetailInvoice.InvoiceId = invoiceId;
            }
            ViewData["invoiceId"] = invoiceId;

            Invoices = new SelectList(_service.GetListInvoices());
            Products = new SelectList(_serviceProduct.ProductSelectList());
            return Page();
        }

        [BindProperty]
        public SaveDetailInvoiceDto DetailInvoice { get; set; }
        public SelectList Invoices { get; set; }
        public SelectList Products { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DetailInvoice.ProductId = _serviceProduct.GetProductId(DetailInvoice.ProductName);
            var t = _serviceProduct.GetProduct(DetailInvoice.ProductId);
            t.Quantity = t.Quantity + DetailInvoice.Quantity;
            DetailInvoice.Price = t.Price;
            DetailInvoice.TotalCost = DetailInvoice.Price * DetailInvoice.Quantity;

            _service.CreateDetailInvoice(DetailInvoice);
           // _serviceInvoice.UpdateCostInvoice(DetailInvoice.InvoiceId, _service.GetTotalCost(DetailInvoice.InvoiceId));
            _serviceProduct.UpdateProduct(_mapper.Map<ProductDto,SaveProductDto>(t));
            
            Response.Cookies.Append("invoiceId", DetailInvoice.InvoiceId.ToString());
            Response.Cookies.Append("timeCheck", "true");
            return RedirectToPage("Index");

        }
    }
}
