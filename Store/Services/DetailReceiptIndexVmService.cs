using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class DetailReceiptIndexVmService : IDetailReceiptIndexVmService
    {
        private int pageSize = 10;
        private readonly IReceiptService _service;
        public DetailReceiptIndexVmService(IReceiptService service)
        {
            _service = service;
        }
        public DetailReceiptIndexVm GetDetailReceiptListVm(int receiptID,int product,int quantityFrom, int quantityTo, int costFrom, int costTo, int pageIndex)
        {
            int count;
            var list = _service.GetDetailReceipts(receiptID,product, quantityFrom, quantityTo, costFrom, costTo, pageIndex, pageSize, out count);
            var receipts = _service.GetListReceipts("chitiet");
            var products = _service.GetListProducts();
            var receiptMainCode = _service.GetReceipt(receiptID);
            return new DetailReceiptIndexVm
            {
                Products = new SelectList(products),
                Receipts = new SelectList(receipts),
                Receipt = receiptMainCode,
                DetailReceipts = new PaginatedList<DetailReceiptDto>(list, pageIndex, pageSize, count)
            };
        }
    }
}