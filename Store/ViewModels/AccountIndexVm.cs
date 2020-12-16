using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.ViewModels
{
    public class AccountIndexVm
    {
        public PaginatedList<AccountDto> Accounts { get; set; }
    }
}