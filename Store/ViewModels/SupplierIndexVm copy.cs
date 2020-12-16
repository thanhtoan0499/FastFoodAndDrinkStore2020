using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class SupplierIndexVm
    {

        public PaginatedList<SupplierDto> Suppliers { get; set; }
    }
}