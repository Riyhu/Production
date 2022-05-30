using Microsoft.EntityFrameworkCore;
using Production.Contracts;
using Production.Entities.AdventureContexts;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Repository
{
    public class ProductSubCategoryRepository : RepositoryBase<ProductSubcategory>, IProductSubCategoryRepository
    {
        public ProductSubCategoryRepository(AdventureContext adventure) : base(adventure)
        {
        }


        public void CreateProductSubCategory(ProductSubcategory productSubcategory)
        {
            Create(productSubcategory);
        }

        public void DeleteProductSubCategory(ProductSubcategory productSubcategory)
        {
            Delete(productSubcategory);
        }

        public async Task<IEnumerable<ProductSubcategory>> GetAllProductSubCategory(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.ProductSubcategoryID)
                .ToListAsync(); 

        public async Task<ProductSubcategory> GetProductSubCategoryByID(int id, bool trackChanges)
           => await FindByCondition(x => x.ProductSubcategoryID.Equals(id), trackChanges).SingleOrDefaultAsync();


        public void UpdateProductSubCategory(ProductSubcategory productSubcategory)
        {
            Update(productSubcategory);
        }
    }
}
