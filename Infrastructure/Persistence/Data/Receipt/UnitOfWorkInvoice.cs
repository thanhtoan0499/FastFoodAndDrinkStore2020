using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkReceipt : IUnitOfWorkReceipt
    {
        private readonly ReceiptContext _context;

        public UnitOfWorkReceipt(ReceiptContext context)
        {
            Receipts = new ReceiptRepository(context);
            _context = context;
        }

        public IReceiptRepository Receipts { get; private set; }

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