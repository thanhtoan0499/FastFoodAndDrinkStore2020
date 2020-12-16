using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWorkStaff : IDisposable
    {
        IStaffRepository Staffs { get; }
        int Complete();
    }
}