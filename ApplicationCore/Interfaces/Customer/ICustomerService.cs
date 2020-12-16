using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        CustomerDto GetCustomer(int id);
        IEnumerable<CustomerDto> GetCustomers(string code, string name, string gender, string phone, int pageIndex, int pageSize, out int count);
        IEnumerable<int> GetListCustomers();
        IEnumerable<CustomerDto> GetAll();
        void CreateCustomer(SaveCustomerDto productDto);
        void UpdateCustomer(SaveCustomerDto productDto);
        void DeleteCustomer(int id);
    }
}