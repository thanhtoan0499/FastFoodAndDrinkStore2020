using Store.ViewModels;

namespace Store.Interfaces
{
    public interface IStaffIndexVmService
    {
        StaffIndexVm GetStaffListVm(string code, string lastName, string firstName, string gender, string position, int pageIndex = 1);
    }
}