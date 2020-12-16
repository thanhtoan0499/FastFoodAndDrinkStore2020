using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext context) : base(context)
        {
        }
        public IEnumerable<int> GetListCustomers()
        {
            return Context.Customers.Select(m => m.id);
        }
        protected new CustomerContext Context => base.Context as CustomerContext;
    }
}