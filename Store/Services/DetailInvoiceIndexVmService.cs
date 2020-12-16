using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class DetailInvoiceIndexVmService : IDetailInvoiceIndexVmService
    {
        private int pageSize = 10;
        private readonly IInvoiceService _service;
        public DetailInvoiceIndexVmService(IInvoiceService service)
        {
            _service = service;
        }
        public DetailInvoiceIndexVm GetDetailInvoiceListVm(int invoiceId, string productName, int quantityFrom, int quantityTo, int costFrom, int costTo, int pageIndex)
        {
            int count;
            var list = _service.GetDetailInvoices(invoiceId, productName, quantityFrom, quantityTo, costFrom, costTo, pageIndex, pageSize, out count);
            var invoices = _service.GetListInvoices("chitiet");
            var products = _service.GetListProducts();
            var invoiceMainCode = _service.GetInvoice(invoiceId);
            return new DetailInvoiceIndexVm
            {
                Products = new SelectList(products),
                Invoices = new SelectList(invoices),
                Invoice = invoiceMainCode,
                DetailInvoices = new PaginatedList<DetailInvoiceDto>(list, pageIndex, pageSize, count)
            };
        }
    }
}