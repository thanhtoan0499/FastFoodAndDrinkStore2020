using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IDetailInvoiceRepository : IRepository<DetailInvoice>
    {
        IEnumerable<int> GetListInvoices();
        IEnumerable<string> GetListProducts();
        IEnumerable<DetailInvoice> GetByInvoiceId(int invoiceId);
        int GetTotalCost(int invoiceId);
    }
}