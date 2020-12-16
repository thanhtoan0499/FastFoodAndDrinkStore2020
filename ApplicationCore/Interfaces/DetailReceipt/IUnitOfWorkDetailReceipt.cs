using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkDetailReceipt : IDisposable
    {
        IDetailReceiptRepository DetailReceipts { get; }
        int Complete();
    }
}