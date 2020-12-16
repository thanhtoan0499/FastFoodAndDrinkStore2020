using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class ProductIndexVmService : IProductIndexVmService
    {
        private int pageSize = 10;
        private readonly IProductService _service;
        public ProductIndexVmService(IProductService service)
        {
            _service = service;
        }
        public ProductIndexVm GetProductListVm(string searchCode, string searchName, string searchType, int searchPriceFrom, int searchPriceTo, int searchQuantityFrom, int searchQuantityTo, int pageIndex)
        {
            int count;
            var products = _service.GetProducts(searchCode, searchName, searchType, searchPriceFrom, searchPriceTo, searchQuantityFrom, searchQuantityTo, pageIndex, pageSize, out count);
            var types = _service.GetTypes();
            return new ProductIndexVm
            {
                Types = new SelectList(types),
                Products = new PaginatedList<ProductDto>(products, pageIndex, pageSize, count)
            };
        }
    }
}