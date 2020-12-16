using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IStaffRepository : IRepository<ApplicationCore.Entities.Staff>
    {
        IEnumerable<string> GetPosition();
        IEnumerable<string> GetListStaffs(string str);
        IEnumerable<int> GetListStaffs();

    }
}