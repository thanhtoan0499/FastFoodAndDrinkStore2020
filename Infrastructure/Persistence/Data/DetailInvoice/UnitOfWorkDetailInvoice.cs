using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkDetailInvoice : IUnitOfWorkDetailInvoice
    {
        private readonly DetailInvoiceContext _context;

        public UnitOfWorkDetailInvoice(DetailInvoiceContext context)
        {
            DetailInvoices = new DetailInvoiceRepository(context);
            _context = context;
        }

        public IDetailInvoiceRepository DetailInvoices { get; private set; }

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