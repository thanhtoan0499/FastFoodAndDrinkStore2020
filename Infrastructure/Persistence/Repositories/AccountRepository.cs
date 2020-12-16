using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
using System;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AccountContext context) : base(context)
        {
        }
        public Account GetByUserName(string username)
        {
            var t =  Context.Accounts.Where(m => m.username == username).Select(m => m);
            if(t == null) return null;
            return t.FirstOrDefault();
        }
        protected new AccountContext Context => base.Context as AccountContext;
    }
}