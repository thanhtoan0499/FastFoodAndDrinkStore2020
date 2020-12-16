using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class DetailReceiptRepository : Repository<DetailReceipt>, IDetailReceiptRepository
    {
        public DetailReceiptRepository(DetailReceiptContext context) : base(context)
        {
        }

        public IEnumerable<int> GetListReceipts()
        {
            var list = from m in Context.DetailReceipts
                       orderby m.ReceiptID
                       select m.ReceiptID;
            return list.Distinct().ToList();
        }
        public IEnumerable<int> GetListProducts()
        {
            var list = from m in Context.DetailReceipts
                       orderby m.ProductID
                       select m.ProductID;
            return list.Distinct().ToList();
        }
        public IEnumerable<DetailReceipt> GetByReceiptId(int ReceiptId)
        {
            return Context.DetailReceipts.Where(m => m.ReceiptID == ReceiptId).Select(m => m);
        }
        public int GetTotalCost(int ReceiptId)
        {
            return Context.DetailReceipts.AsQueryable<DetailReceipt>().Where(m => m.ReceiptID == ReceiptId).Sum(m => m.Cost);

        }
        protected new DetailReceiptContext Context => base.Context as DetailReceiptContext;
    }
}