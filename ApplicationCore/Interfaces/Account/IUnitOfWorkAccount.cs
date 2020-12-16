using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkAccount : IDisposable
    {
        IAccountRepository Accounts { get; }
        int Complete();
    }
}