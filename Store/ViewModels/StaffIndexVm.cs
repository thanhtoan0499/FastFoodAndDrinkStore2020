using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class StaffIndexVm
    {
        public PaginatedList<StaffDto> Staffs { get; set; }
        public SelectList Positions { get; set; }
    }
}