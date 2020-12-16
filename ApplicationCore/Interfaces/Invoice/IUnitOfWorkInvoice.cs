using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkInvoice : IDisposable
    {
        IInvoiceRepository Invoices { get; }
        int Complete();
    }
}