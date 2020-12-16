using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class AccountIndexVmService : IAccountIndexVmService
    {
        private int pageSize = 10;
        private readonly IAccountService _service;
        public AccountIndexVmService(IAccountService service)
        {
            _service = service;
        }
        public AccountIndexVm GetAccountListVm(int pageIndex)
        {
            int count;
            var products = _service.GetAccounts(pageIndex, pageSize, out count);
            return new AccountIndexVm
            {
                Accounts = new PaginatedList<AccountDto>(products, pageIndex, pageSize, count)
            };
        }
    }
}