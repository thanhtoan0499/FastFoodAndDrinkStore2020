using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(SupplierContext context) : base(context)
        {
        }

        public IEnumerable<string> GetListSuppliers()
        {
            var goods = from m in Context.Suppliers
                        orderby m.Name
                        select m.Name;
            return goods.Distinct().ToList();
        }
        protected new SupplierContext Context => base.Context as SupplierContext;
    }
}