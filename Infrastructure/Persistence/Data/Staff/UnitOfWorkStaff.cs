using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWorkStaff : IUnitOfWorkStaff
    {
        private readonly StaffContext _context;

        public UnitOfWorkStaff(StaffContext context)
        {
            Staffs = new StaffRepository(context);
            _context = context;
        }

        public IStaffRepository Staffs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}