using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
using System;

namespace Infrastructure.Persistence.Repositories
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(PromotionContext context) : base(context)
        {
        }
        public IEnumerable<string> GetListPromotions()
        {
            var list = from m in Context.Promotions
                       orderby m.Name
                       select m.Name;
            return list.Distinct().ToList();
        }
        public Promotion GetProByCode(string name)
        {
            var pro = Context.Promotions.Where(m=> m.Name == name).ToList().FirstOrDefault();
            return pro;

        }
        protected new PromotionContext Context => base.Context as PromotionContext;
    }
}