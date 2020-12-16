using Store.ViewModels;

namespace Store.Interfaces
{
    public interface IDetailInvoiceIndexVmService
    {
        DetailInvoiceIndexVm GetDetailInvoiceListVm(int invoiceId, string productName, int quantityFrom, int quantityTo, int costFrom, int costTo, int pageIndex = 1);
    }
}