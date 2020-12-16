using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Interfaces;
using Store.ViewModels;
using System.Linq;
namespace Store.Services
{
    public class StaffIndexVmService : IStaffIndexVmService
    {
        private int pageSize = 10;
        private readonly IStaffService _service;
        public StaffIndexVmService(IStaffService service)
        {
            _service = service;
        }
        public StaffIndexVm GetStaffListVm(string code, string lastName, string firstName, string gender, string position, int pageIndex)
        {
            int count;
            var Staffs = _service.GetStaffs(code, lastName, firstName, gender, position, pageIndex, pageSize, out count);
            var positions = _service.GetPosition();
            return new StaffIndexVm
            {
                Positions = new SelectList(positions),
                Staffs = new PaginatedList<StaffDto>(Staffs, pageIndex, pageSize, count)
            };
        }
    }
}