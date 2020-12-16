using Store.ViewModels;

namespace Store.Interfaces
{
    public interface IProductIndexVmService
    {
        ProductIndexVm GetProductListVm(string searchCode, string searchName, string searchType, int searchPriceFrom, int searchPriceTo, int searchQuantityFrom, int searchQuantityTo, int pageIndex = 1);
    }
}