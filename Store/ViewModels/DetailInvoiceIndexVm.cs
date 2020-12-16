using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class DetailInvoiceIndexVm
    {
        public PaginatedList<DetailInvoiceDto> DetailInvoices { get; set; }
        public SelectList Invoices { get; set; }
        public SelectList Products { get; set; }

        public InvoiceDto Invoice { get; set; }
    }
}