using Store.ViewModels;

namespace Store.Interfaces
{
    public interface ICustomerIndexVmService
    {
        CustomerIndexVm GetCustomerListVm(string code, string name, string gender, string phone, int pageIndex = 1);
    }
}