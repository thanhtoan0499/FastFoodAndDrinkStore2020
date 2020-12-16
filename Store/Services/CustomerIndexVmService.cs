using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class CustomerIndexVmService : ICustomerIndexVmService
    {
        private int pageSize = 10;
        private readonly ICustomerService _service;
        public CustomerIndexVmService(ICustomerService service)
        {
            _service = service;
        }
        public CustomerIndexVm GetCustomerListVm(string code, string name, string gender, string phone, int pageIndex)
        {
            int count;
            var products = _service.GetCustomers(code, name, gender, phone, pageIndex, pageSize, out count);
            return new CustomerIndexVm
            {
                Customers = new PaginatedList<CustomerDto>(products, pageIndex, pageSize, count)
            };
        }
    }
}