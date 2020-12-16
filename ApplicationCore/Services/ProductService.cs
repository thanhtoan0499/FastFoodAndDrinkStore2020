using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkProduct _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWorkProduct unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductDto GetProduct(int id)
        {
            var product = _unitOfWork.Products.GetBy(id);
            return _mapper.Map<Product, ProductDto>(product);
        }
        public int GetProductId(string name)
        {
            return _unitOfWork.Products.GetProductId(name);
        }
      
        public IEnumerable<ProductDto> GetAll()
        {
            var allProducts = _unitOfWork.Products.GetAll();
            return _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(allProducts);
        }

        public IEnumerable<ProductDto> GetProducts(string searchCode, string searchName, string searchType, int searchPriceFrom, int searchPriceTo, int searchQuantityFrom, int searchQuantityTo, int pageIndex, int pageSize, out int count)
        {
            ProductSpecification spec = new ProductSpecification(searchCode, searchName, searchType, searchPriceFrom, searchPriceTo, searchQuantityFrom, searchQuantityTo, pageIndex, pageSize);
            ProductSpecification spec1 = new ProductSpecification(searchCode, searchName, searchType, searchPriceFrom, searchPriceTo, searchQuantityFrom, searchQuantityTo);

            var product = _unitOfWork.Products.Find(spec);
            count = _unitOfWork.Products.Count(spec1);

            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(product);
        }
     
        public IEnumerable<string> GetTypes()
        {
            return _unitOfWork.Products.GetTypes();
        }
        public IEnumerable<string> ProductSelectList()
        {
            return _unitOfWork.Products.ProductSelectList();
        }
        public  IEnumerable<int> GetListProducts()
        {
            return _unitOfWork.Products.GetListProducts();
        }
        public void CreateProduct(SaveProductDto saveProductDto)
        {
            var product = _mapper.Map<SaveProductDto, Product>(saveProductDto);
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
        }
        public void UpdateProduct(SaveProductDto saveProductDto)
        {
            var product = _unitOfWork.Products.GetBy(saveProductDto.id);
            if (product == null) return;
            _mapper.Map<SaveProductDto, Product>(saveProductDto, product);
            _unitOfWork.Complete();
        }
        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.Products.GetBy(id);
            if (product != null)
            {
                _unitOfWork.Products.Remove(product);
                _unitOfWork.Complete();
            }
        }
    }
}