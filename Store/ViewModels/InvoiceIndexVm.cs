using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class InvoiceIndexVm
    {
        public PaginatedList<InvoiceDto> Invoices { get; set; }
        public SelectList Staff { get; set; }
        public SelectList Supplier { get; set; }
    }
}