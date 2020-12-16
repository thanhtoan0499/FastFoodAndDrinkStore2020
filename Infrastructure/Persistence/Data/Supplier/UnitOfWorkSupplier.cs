using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkSupplier : IUnitOfWorkSupplier
    {
        private readonly SupplierContext _context;

        public UnitOfWorkSupplier(SupplierContext context)
        {
            Suppliers = new SupplierRepository(context);
            _context = context;
        }

        public ISupplierRepository Suppliers { get; private set; }

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