using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWorkStaff _unitOfWork;
        private readonly IMapper _mapper;
        public StaffService(IUnitOfWorkStaff unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public StaffDto GetStaff(int id)
        {
            var Staff = _unitOfWork.Staffs.GetBy(id);
            return _mapper.Map<Staff, StaffDto>(Staff);
        }
        public IEnumerable<StaffDto> GetStaffs(string code, string lastName, string firstName, string gender, string position, int pageIndex, int pageSize, out int count)
        {
            StaffSpecification spec = new StaffSpecification(code, lastName, firstName, gender, position, pageIndex, pageSize);
            StaffSpecification spec1 = new StaffSpecification(code, lastName, firstName, gender, position);

            var Staff = _unitOfWork.Staffs.Find(spec);
            count = _unitOfWork.Staffs.Count(spec1);

            return _mapper.Map<IEnumerable<Staff>, IEnumerable<StaffDto>>(Staff);
        }
        public IEnumerable<string> GetPosition()
        {
            return _unitOfWork.Staffs.GetPosition();
        }
        public IEnumerable<string> GetListStaffs(string str)
        {
            return _unitOfWork.Staffs.GetListStaffs(str);
        }
        public IEnumerable<int> GetListStaffs()
        {
            return _unitOfWork.Staffs.GetListStaffs();
        }
        public IEnumerable<StaffDto> GetAll()
        {
            var Staffs = _unitOfWork.Staffs.GetAll();
            return _mapper.Map<IEnumerable<Staff>,IEnumerable<StaffDto>>(Staffs);
        }
        public void CreateStaff(SaveStaffDto saveStaffDto)
        {
            var Staff = _mapper.Map<SaveStaffDto, Staff>(saveStaffDto);
            _unitOfWork.Staffs.Add(Staff);
            _unitOfWork.Complete();
        }
        public void UpdateStaff(SaveStaffDto saveStaffDto)
        {
            var Staff = _unitOfWork.Staffs.GetBy(saveStaffDto.id);
            if (Staff == null) return;
            _mapper.Map<SaveStaffDto, Staff>(saveStaffDto, Staff);
            _unitOfWork.Complete();
        }
        public void DeleteStaff(int id)
        {
            var Staff = _unitOfWork.Staffs.GetBy(id);
            if (Staff != null)
            {
                _unitOfWork.Staffs.Remove(Staff);
                _unitOfWork.Complete();
            }
        }
    }
}