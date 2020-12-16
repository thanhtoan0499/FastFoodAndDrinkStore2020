using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceContext context) : base(context)
        {
        }
        public IEnumerable<int> GetListInvoices()
        {
            var rtype = from m in Context.Invoices
                        orderby m.id
                        select m.id;
            return rtype.Distinct().ToList();
        }
        public IEnumerable<string> GetStaffs()
        {
            var staff = from m in Context.Invoices
                        orderby m.Staff
                        select m.Staff;
            return staff.Distinct().ToList();
        }
        public IEnumerable<string> GetSuppliers()
        {
            var supplier = from m in Context.Invoices
                           orderby m.Supplier
                           select m.Supplier;
            return supplier.Distinct().ToList();
        }
        protected new InvoiceContext Context => base.Context as InvoiceContext;
    }
}