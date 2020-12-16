using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkAccount : IUnitOfWorkAccount
    {
        private readonly AccountContext _context;

        public UnitOfWorkAccount(AccountContext context)
        {
            Accounts = new AccountRepository(context);
            _context = context;
        }

        public IAccountRepository Accounts { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}