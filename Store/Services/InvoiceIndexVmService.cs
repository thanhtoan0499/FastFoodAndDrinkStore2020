using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class InvoiceIndexVmService : IInvoiceIndexVmService
    {
        private int pageSize = 10;
        private readonly IInvoiceService _service;
        public InvoiceIndexVmService(IInvoiceService service)
        {
            _service = service;
        }
        public InvoiceIndexVm GetInvoiceListVm(string staff, string supplier, int costFrom, int costTo, int pageIndex)
        {
            int count;
            var products = _service.GetInvoices(staff, supplier, costFrom, costTo, pageIndex, pageSize, out count);
            var staffs = _service.GetStaffs();
            var suppliers = _service.GetSuppliers();
            return new InvoiceIndexVm
            {
                Staff = new SelectList(staffs),
                Supplier = new SelectList(suppliers),
                Invoices = new PaginatedList<InvoiceDto>(products, pageIndex, pageSize, count)
            };
        }
    }
}