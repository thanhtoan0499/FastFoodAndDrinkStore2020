using System;
using Store.ViewModels;

namespace Store.Interfaces
{
    public interface IPromotionIndexVmService
    {
        PromotionIndexVm GetPromotionListVm(string name, int discountFrom, int discountTo, DateTime start, DateTime end, int pageIndex = 1);
    }
}