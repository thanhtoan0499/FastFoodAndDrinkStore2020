using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkCustomer : IUnitOfWorkCustomer
    {
        private readonly CustomerContext _context;

        public UnitOfWorkCustomer(CustomerContext context)
        {
            Customers = new CustomerRepository(context);
            _context = context;
        }

        public ICustomerRepository Customers { get; private set; }

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