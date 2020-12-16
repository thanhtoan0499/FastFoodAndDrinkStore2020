using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IDetailReceiptRepository : IRepository<DetailReceipt>
    {
        IEnumerable<int> GetListReceipts();
        IEnumerable<int> GetListProducts();
        IEnumerable<DetailReceipt> GetByReceiptId(int receiptID);
        int GetTotalCost(int receiptID);
    }
}