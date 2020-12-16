using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface ISupplierService
    {
        SupplierDto GetSupplier(int id);
        IEnumerable<SupplierDto> GetSuppliers(string id, string name, int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetListSuppliers();
        IEnumerable<SupplierDto> GetAll();
        void CreateSupplier(SaveSupplierDto productDto);
        void UpdateSupplier(SaveSupplierDto productDto);
        void DeleteSupplier(int id);
    }
}