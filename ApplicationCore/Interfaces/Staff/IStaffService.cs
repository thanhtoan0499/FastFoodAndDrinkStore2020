using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IStaffService
    {
        StaffDto GetStaff(int id);
        IEnumerable<StaffDto> GetStaffs(string code, string lastName, string firstName, string gender, string position, int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetPosition();
        IEnumerable<string> GetListStaffs(string str);
        IEnumerable<int> GetListStaffs();
        IEnumerable<StaffDto> GetAll();
        void CreateStaff(SaveStaffDto StaffDto);
        void UpdateStaff(SaveStaffDto StaffDto);
        void DeleteStaff(int id);
    }
}