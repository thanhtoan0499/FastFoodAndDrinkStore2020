using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class ReceiptIndexVmService : IReceiptIndexVmService
    {
        private int pageSize = 10;
        private readonly IReceiptService _service;
        public ReceiptIndexVmService(IReceiptService service)
        {
            _service = service;
        }
        public ReceiptIndexVm GetReceiptListVm(int id, int staff, int customer,DateTime dateFrom, DateTime dateTo, int costFrom, int costTo, int pageIndex)
        {
            int count;
            var receipt = _service.GetReceipts(id, staff, customer,dateFrom, dateTo, costFrom, costTo, pageIndex, pageSize, out count);
            var staffs = _service.GetStaffs();
            var customers = _service.GetCustomers();
            return new ReceiptIndexVm
            {
                Staff = new SelectList(staffs),
                Customer = new SelectList(customers),
                Receipts = new PaginatedList<ReceiptDto>(receipt, pageIndex, pageSize, count)
            };
        }
    }
}