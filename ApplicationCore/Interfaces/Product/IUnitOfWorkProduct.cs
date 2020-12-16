using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkProduct : IDisposable
    {
        IProductRepository Products { get; }
        int Complete();
    }
}