using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByUserName(string username);
    }
}