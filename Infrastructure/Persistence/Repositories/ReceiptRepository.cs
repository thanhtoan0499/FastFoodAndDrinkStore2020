using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ReceiptContext context) : base(context)
        {
        }
        public IEnumerable<int> GetListReceipts()
        {
            var rtype = from m in Context.Receipts
                        orderby m.id
                        select m.id;
            return rtype.Distinct().ToList();
        }
        public IEnumerable<int> GetStaffs()
        {
            var staff = from m in Context.Receipts
                        orderby m.StaffID
                        select m.StaffID;
            return staff.Distinct().ToList();
        }
        public IEnumerable<int> GetCustomers()
        {
            var supplier = from m in Context.Receipts
                           orderby m.CustomerID
                           select m.CustomerID;
            return supplier.Distinct().ToList();
        }
        protected new ReceiptContext Context => base.Context as ReceiptContext;
    }
}