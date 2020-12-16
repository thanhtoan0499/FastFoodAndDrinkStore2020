using Store.ViewModels;

namespace Store.Interfaces
{
    public interface IInvoiceIndexVmService
    {
        InvoiceIndexVm GetInvoiceListVm(string staff, string supplier, int costFrom, int costTo, int pageIndex = 1);
    }
}