using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategory(bool trackChanges);
        Task<ProductCategory> GetProductCategoryByID(int id, bool trackChanges);
        void CreateProductCategory(ProductCategory productSubcategory);
        void DeleteProductCategory(ProductCategory productSubcategory);
        void UpdateProductCategory(ProductCategory productSubcategory);
    }
}
