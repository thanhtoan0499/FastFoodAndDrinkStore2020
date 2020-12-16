using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class CustomerIndexVm
    {
        public PaginatedList<CustomerDto> Customers { get; set; }
    }
}