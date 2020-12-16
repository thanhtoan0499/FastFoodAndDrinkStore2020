using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkCustomer : IDisposable
    {
        ICustomerRepository Customers { get; }
        int Complete();
    }
}