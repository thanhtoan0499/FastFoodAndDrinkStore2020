using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        IEnumerable<int> GetListInvoices();
        IEnumerable<string> GetStaffs();
        IEnumerable<string> GetSuppliers();
    }
}