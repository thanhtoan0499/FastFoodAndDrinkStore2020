using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class ProductIndexVm
    {
        public PaginatedList<ProductDto> Products { get; set; }
        public SelectList Types { get; set; }
    }
}