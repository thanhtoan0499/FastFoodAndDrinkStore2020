using Store.ViewModels;
using System;
namespace Store.Interfaces
{
    public interface IReceiptIndexVmService
    {
        ReceiptIndexVm GetReceiptListVm(int id, int staff, int customer, DateTime dateFrom, DateTime dateTo, int costFrom, int costTo, int pageIndex = 1);
    }
}