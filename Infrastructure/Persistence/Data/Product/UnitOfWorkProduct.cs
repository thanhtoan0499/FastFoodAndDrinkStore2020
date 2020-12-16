using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkProduct : IUnitOfWorkProduct
    {
        private readonly ProductContext _context;

        public UnitOfWorkProduct(ProductContext context)
        {
            Products = new ProductRepository(context);
            _context = context;
        }

        public IProductRepository Products { get; private set; }

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