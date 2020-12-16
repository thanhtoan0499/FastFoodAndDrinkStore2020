using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWorkSupplier _unitOfWork;
        private readonly IMapper _mapper;
        public SupplierService(IUnitOfWorkSupplier unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SupplierDto GetSupplier(int id)
        {
            var product = _unitOfWork.Suppliers.GetBy(id);
            return _mapper.Map<Supplier, SupplierDto>(product);
        }
        public IEnumerable<SupplierDto> GetSuppliers(string id, string name, int pageIndex, int pageSize, out int count)
        {
            SupplierSpecification spec = new SupplierSpecification(id,name, pageIndex, pageSize);
            SupplierSpecification spec1 = new SupplierSpecification(id, name);

            var product = _unitOfWork.Suppliers.Find(spec);
            count = _unitOfWork.Suppliers.Count(spec1);

            return _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDto>>(product);
        }
        public IEnumerable<SupplierDto> GetAll()
        {
            var supplier = _unitOfWork.Suppliers.GetAll();
            return _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDto>>(supplier);
        }
     
        public IEnumerable<string> GetListSuppliers()
        {
            return _unitOfWork.Suppliers.GetListSuppliers();
        }
        public void CreateSupplier(SaveSupplierDto saveSupplierDto)
        {
            var product = _mapper.Map<SaveSupplierDto, Supplier>(saveSupplierDto);
            _unitOfWork.Suppliers.Add(product);
            _unitOfWork.Complete();
        }
        public void UpdateSupplier(SaveSupplierDto saveSupplierDto)
        {
            var product = _unitOfWork.Suppliers.GetBy(saveSupplierDto.id);
            if (product == null) return;
            _mapper.Map<SaveSupplierDto, Supplier>(saveSupplierDto, product);
            _unitOfWork.Complete();
        }
        public void DeleteSupplier(int id)
        {
            var product = _unitOfWork.Suppliers.GetBy(id);
            if (product != null)
            {
                _unitOfWork.Suppliers.Remove(product);
                _unitOfWork.Complete();
            }
        }
    }
}