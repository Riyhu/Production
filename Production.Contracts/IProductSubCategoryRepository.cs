using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IProductSubCategoryRepository
    {
        Task<IEnumerable<ProductSubcategory>> GetAllProductSubCategory(bool trackChanges);
        Task<ProductSubcategory> GetProductSubCategoryByID(int id, bool trackChanges);
        void CreateProductSubCategory(ProductSubcategory productSubcategory);
        void DeleteProductSubCategory(ProductSubcategory productSubcategory);
        void UpdateProductSubCategory(ProductSubcategory productSubcategory);
    }
}
