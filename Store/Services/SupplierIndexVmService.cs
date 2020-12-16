using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class SupplierIndexVmService : ISupplierIndexVmService
    {
        private int pageSize = 10;
        private readonly ISupplierService _service;
        public SupplierIndexVmService(ISupplierService service)
        {
            _service = service;
        }
        public SupplierIndexVm GetSupplierListVm(string id, string name, int pageIndex)
        {
            int count;
            var products = _service.GetSuppliers(id, name, pageIndex, pageSize, out count);
            return new SupplierIndexVm
            {
                Suppliers = new PaginatedList<SupplierDto>(products, pageIndex, pageSize, count)
            };
        }
    }
}