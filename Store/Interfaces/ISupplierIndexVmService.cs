using Store.ViewModels;

namespace Store.Interfaces
{
    public interface ISupplierIndexVmService
    {
        SupplierIndexVm GetSupplierListVm(string id, string name, int pageIndex = 1);
    }
}