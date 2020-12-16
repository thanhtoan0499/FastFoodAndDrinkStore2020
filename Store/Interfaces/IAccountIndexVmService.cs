using System;
using Store.ViewModels;

namespace Store.Interfaces
{
    public interface IAccountIndexVmService
    {
        AccountIndexVm GetAccountListVm(int pageIndex = 1);
    }
}