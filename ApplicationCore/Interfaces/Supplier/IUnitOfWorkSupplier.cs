using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkSupplier : IDisposable
    {
        ISupplierRepository Suppliers { get; }
        int Complete();
    }
}