using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using ApplicationCore.Mapping;
namespace Store.Pages.DetailInvoices
{
    public class DeleteModel : PageModel
    {
        private readonly IInvoiceService _service;
        private readonly IProductService _serviceProduct;
        private readonly IMapper _mapper;
        public DeleteModel(IInvoiceService service, IProductService serviceProduct,IMapper mapper)
        {
            _service = service;
            _serviceProduct = serviceProduct;
            _mapper = mapper;
        }

        [BindProperty]
        public DetailInvoiceDto DetailInvoice { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("../Accounts/Login");
            if(t == "false") return RedirectToPage("../Accounts/Login");
            
            if (id == null)
            {
                return NotFound();
            }

            DetailInvoice = _service.GetDetailInvoice(id ?? default(int));

            if (DetailInvoice == null)
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

            var detailInvoice = _service.GetDetailInvoice(id ?? default(int));
            _service.DeleteDetailInvoice(id ?? default(int));
            //_service.UpdateCostInvoice(detailInvoice.InvoiceId, _service.GetTotalCost(detailInvoice.InvoiceId));
            var t = _serviceProduct.GetProduct(detailInvoice.ProductId);
            t.Quantity = t.Quantity - detailInvoice.Quantity;
            _serviceProduct.UpdateProduct(_mapper.Map<ProductDto,SaveProductDto>(t));
            Response.Cookies.Append("invoiceId", detailInvoice.InvoiceId.ToString());
            Response.Cookies.Append("timeCheck", "true");
            return RedirectToPage("./Index");
        }
    }
}
