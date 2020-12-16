using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class ReceiptIndexVm
    {
        public PaginatedList<ReceiptDto> Receipts { get; set; }
        public SelectList Staff { get; set; }
        public SelectList Customer { get; set; }
    }
}