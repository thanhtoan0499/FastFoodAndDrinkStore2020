using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkDetailReceipt : IUnitOfWorkDetailReceipt
    {
        private readonly DetailReceiptContext _context;

        public UnitOfWorkDetailReceipt(DetailReceiptContext context)
        {
            DetailReceipts = new DetailReceiptRepository(context);
            _context = context;
        }

        public IDetailReceiptRepository DetailReceipts { get; private set; }

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