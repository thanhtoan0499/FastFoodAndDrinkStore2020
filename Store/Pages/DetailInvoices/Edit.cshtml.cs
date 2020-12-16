using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.DetailInvoices
{
    public class EditModel : PageModel
    {
        private readonly IInvoiceService _service;
        private readonly IProductService _serviceProduct;
        private readonly IMapper _mapper;

        public EditModel(IMapper mapper, IInvoiceService service, IProductService serviceProduct)
        {
            _mapper = mapper;
            _service = service;
            _serviceProduct = serviceProduct;
        }

        [BindProperty]
        public SaveDetailInvoiceDto DetailInvoice { get; set; }

        public SelectList Invoices { get; set; }

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

            var pDetailInvoice = _service.GetDetailInvoice(id ?? default(int));

            if (pDetailInvoice == null)
            {
                return NotFound();
            }

            Invoices = new SelectList(_service.GetListInvoices());
            Products = new SelectList(_serviceProduct.ProductSelectList());

            DetailInvoice = _mapper.Map<DetailInvoiceDto, SaveDetailInvoiceDto>(pDetailInvoice);

            TemQuantity = DetailInvoice.Quantity;
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
                //get references from product product id, price and calc totalcost
                DetailInvoice.ProductId = _serviceProduct.GetProductId(DetailInvoice.ProductName);
                var t = _serviceProduct.GetProduct(DetailInvoice.ProductId);
                DetailInvoice.Price = t.Price;
                DetailInvoice.TotalCost = DetailInvoice.Price * DetailInvoice.Quantity;
                t.Quantity = t.Quantity - TemQuantity + DetailInvoice.Quantity;
                _service.UpdateDetailInvoice(DetailInvoice);
                //update total cost from invoice
                //_serviceInvoice.UpdateCostInvoice(DetailInvoice.InvoiceId, _service.GetTotalCost(DetailInvoice.InvoiceId));
                _serviceProduct.UpdateProduct(_mapper.Map<ProductDto,SaveProductDto>(t));
                Response.Cookies.Append("invoiceId", DetailInvoice.InvoiceId.ToString());
                Response.Cookies.Append("timeCheck", "true");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailInvoiceExists(DetailInvoice.id))
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
        private bool DetailInvoiceExists(int id)
        {
            return _service.GetDetailInvoice(id) != null;
        }
    }
}
