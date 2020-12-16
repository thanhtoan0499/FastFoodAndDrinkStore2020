using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IProductService
    {
        ProductDto GetProduct(int id);
        IEnumerable<ProductDto> GetProducts(string searchCode, string searchName, string searchType, int searchPriceFrom, int searchPriceTo, int searchQuantityFrom, int searchQuantityTo, int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetTypes();
    
        IEnumerable<ProductDto> GetAll();
        IEnumerable<string> ProductSelectList();
        IEnumerable<int> GetListProducts();
        int GetProductId(string name);
        void CreateProduct(SaveProductDto productDto);
        void UpdateProduct(SaveProductDto productDto);
        void DeleteProduct(int id);
    }
}