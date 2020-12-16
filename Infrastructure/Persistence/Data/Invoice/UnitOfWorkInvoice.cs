using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkInvoice : IUnitOfWorkInvoice
    {
        private readonly InvoiceContext _context;

        public UnitOfWorkInvoice(InvoiceContext context)
        {
            Invoices = new InvoiceRepository(context);
            _context = context;
        }

        public IInvoiceRepository Invoices { get; private set; }

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