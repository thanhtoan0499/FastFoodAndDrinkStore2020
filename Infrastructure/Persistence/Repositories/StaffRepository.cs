using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
namespace Infrastructure.Persistence.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(StaffContext context) : base(context)
        {
        }
        public IEnumerable<string> GetPosition()
        {
            var rtype = from m in Context.Staffs
                        orderby m.Position
                        select m.Position;
            return rtype.Distinct().ToList();
        }
        public IEnumerable<string> GetListStaffs(string str)
        {
            var rtype = from m in Context.Staffs
                        orderby m.FirstName
                        select m.LastName + " " + m.FirstName;
            return rtype.Distinct().ToList();
        }
        public IEnumerable<int> GetListStaffs()
        {
            return Context.Staffs.Select(m => m.id);
        }
        protected new StaffContext Context => base.Context as StaffContext;
    }
}