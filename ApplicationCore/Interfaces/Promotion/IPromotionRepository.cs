using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        Promotion GetProByCode(string code);
        IEnumerable<string> GetListPromotions();
    }
}