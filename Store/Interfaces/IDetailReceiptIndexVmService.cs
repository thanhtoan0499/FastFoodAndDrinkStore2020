using Store.ViewModels;

namespace Store.Interfaces
{
    public interface IDetailReceiptIndexVmService
    {
        DetailReceiptIndexVm GetDetailReceiptListVm(int receiptID,int product,int quantityFrom, int quantityTo, int costFrom, int costTo, int pageIndex = 1);
    }
}