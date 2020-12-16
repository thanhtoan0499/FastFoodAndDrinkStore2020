using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkPromotion : IUnitOfWorkPromotion
    {
        private readonly PromotionContext _context;

        public UnitOfWorkPromotion(PromotionContext context)
        {
            Promotions = new PromotionRepository(context);
            _context = context;
        }

        public IPromotionRepository Promotions { get; private set; }

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