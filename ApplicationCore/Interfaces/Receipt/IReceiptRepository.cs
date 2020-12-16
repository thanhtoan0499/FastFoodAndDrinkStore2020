using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        IEnumerable<int> GetListReceipts();
        IEnumerable<int> GetStaffs();
        IEnumerable<int> GetCustomers();
    }
}