using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
        public IEnumerable<string> GetTypes()
        {
            var rtype = from m in Context.Products
                        orderby m.Type
                        select m.Type;
            return rtype.Distinct().ToList();
        }
        public IEnumerable<string> ProductSelectList()
        {
            var rtype = from m in Context.Products
                        orderby m.Name
                        select m.Name;
            return rtype.ToList();
        }
        public  IEnumerable<int> GetListProducts()
        {
            return Context.Products.Select(m => m.id);
        }
        public int GetProductId(string name)
        {
            var t = Context.Products.AsQueryable().Where(m=>m.Name == name).Select(m=> m.id);
            return t.ToList()[0];
        }
        protected new ProductContext Context => base.Context as ProductContext;
    }
}