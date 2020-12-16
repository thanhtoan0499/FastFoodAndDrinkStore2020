using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class PromotionIndexVmService : IPromotionIndexVmService
    {
        private int pageSize = 10;
        private readonly IPromotionService _service;
        public PromotionIndexVmService(IPromotionService service)
        {
            _service = service;
        }
        public PromotionIndexVm GetPromotionListVm(string name, int discountFrom, int discountTo, DateTime start, DateTime end, int pageIndex)
        {
            int count;
            var products = _service.GetPromotions(name, discountFrom, discountTo, start, end, pageIndex, pageSize, out count);
            return new PromotionIndexVm
            {
                Promotions = new PaginatedList<PromotionDto>(products, pageIndex, pageSize, count)
            };
        }
    }
}