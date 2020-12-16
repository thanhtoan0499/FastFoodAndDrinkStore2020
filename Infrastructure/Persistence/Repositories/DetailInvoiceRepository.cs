using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class DetailInvoiceRepository : Repository<DetailInvoice>, IDetailInvoiceRepository
    {
        public DetailInvoiceRepository(DetailInvoiceContext context) : base(context)
        {
        }

        public IEnumerable<int> GetListInvoices()
        {
            var list = from m in Context.DetailInvoices
                       orderby m.InvoiceId
                       select m.InvoiceId;
            return list.Distinct().ToList();
        }
        public IEnumerable<string> GetListProducts()
        {
            var list = from m in Context.DetailInvoices
                       orderby m.ProductName
                       select m.ProductName;
            return list.Distinct().ToList();
        }
        public IEnumerable<DetailInvoice> GetByInvoiceId(int invoiceId)
        {
            return Context.DetailInvoices.Where(m => m.InvoiceId == invoiceId).Select(m => m);
        }
        public int GetTotalCost(int invoiceId)
        {
            return Context.DetailInvoices.AsQueryable<DetailInvoice>().Where(m => m.InvoiceId == invoiceId).Sum(m => m.TotalCost);

        }
        protected new DetailInvoiceContext Context => base.Context as DetailInvoiceContext;
    }
}