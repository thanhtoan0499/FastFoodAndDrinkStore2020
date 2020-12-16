using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkReceipt : IDisposable
    {
        IReceiptRepository Receipts { get; }
        int Complete();
    }
}