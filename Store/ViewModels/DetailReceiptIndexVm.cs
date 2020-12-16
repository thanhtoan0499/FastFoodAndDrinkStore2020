using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class DetailReceiptIndexVm
    {
        public PaginatedList<DetailReceiptDto> DetailReceipts { get; set; }
        public SelectList Receipts { get; set; }
        public SelectList Products { get; set; }

        public ReceiptDto Receipt { get; set; }
    }
}