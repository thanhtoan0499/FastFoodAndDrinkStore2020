using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkDetailInvoice : IDisposable
    {
        IDetailInvoiceRepository DetailInvoices { get; }
        int Complete();
    }
}