using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWorkCustomer _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWorkCustomer unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.GetBy(id);
            return _mapper.Map<Customer, CustomerDto>(customer);
        }
        public IEnumerable<CustomerDto> GetCustomers(string code, string name, string gender, string phone, int pageIndex, int pageSize, out int count)
        {
            CustomerSpecification spec = new CustomerSpecification(code, name, gender, phone, pageIndex, pageSize);
            CustomerSpecification spec1 = new CustomerSpecification(code, name, gender, phone);

            var customer = _unitOfWork.Customers.Find(spec);
            count = _unitOfWork.Customers.Count(spec1);

            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customer);
        }
        public IEnumerable<int> GetListCustomers()
        {
            return _unitOfWork.Customers.GetListCustomers();
        }
        public IEnumerable<CustomerDto> GetAll()
        {
            var Customers = _unitOfWork.Customers.GetAll();
            return _mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerDto>>(Customers);
        }
        public void CreateCustomer(SaveCustomerDto saveCustomerDto)
        {
            var customer = _mapper.Map<SaveCustomerDto, Customer>(saveCustomerDto);
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();
        }
        public void UpdateCustomer(SaveCustomerDto saveCustomerDto)
        {
            var customer = _unitOfWork.Customers.GetBy(saveCustomerDto.id);
            if (customer == null) return;
            _mapper.Map<SaveCustomerDto, Customer>(saveCustomerDto, customer);
            _unitOfWork.Complete();
        }
        public void DeleteCustomer(int id)
        {
            var customer = _unitOfWork.Customers.GetBy(id);
            if (customer != null)
            {
                _unitOfWork.Customers.Remove(customer);
                _unitOfWork.Complete();
            }
        }
    }
}