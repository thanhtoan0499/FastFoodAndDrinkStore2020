using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        AccountDto GetAccount(int id);
        IEnumerable<AccountDto> GetAccounts(int pageIndex, int pageSize, out int count);
        IEnumerable<AccountDto> GetAll();
        AccountDto GetByUserName(string username);
        void CreateAccount(SaveAccountDto productDto);
        void UpdateAccount(SaveAccountDto productDto);
        void DeleteAccount(int id);
    }
}