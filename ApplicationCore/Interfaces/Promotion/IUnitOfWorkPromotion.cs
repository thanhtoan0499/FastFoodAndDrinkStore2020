using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkPromotion : IDisposable
    {
        IPromotionRepository Promotions { get; }
        int Complete();
    }
}