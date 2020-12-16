using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class PromotionIndexVm
    {
        public PaginatedList<PromotionDto> Promotions { get; set; }
    }
}