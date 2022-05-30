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
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public void CreateProductCategory(ProductCategory productSubcategory)
        {
            Create(productSubcategory);
        }

        public void DeleteProductCategory(ProductCategory productSubcategory)
        {
            Delete(productSubcategory);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategory(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.ProductCategoryID)
                .ToListAsync();

        public async Task<ProductCategory> GetProductCategoryByID(int id, bool trackChanges)
         => await FindByCondition(x => x.ProductCategoryID.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateProductCategory(ProductCategory productSubcategory)
        {
            Update(productSubcategory);
        }
    }
}
