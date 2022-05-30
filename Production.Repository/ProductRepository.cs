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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public async Task<IEnumerable<Product>> GetAllProduct(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(x => x.ProductID).ToListAsync();
        }

        public async Task<Product> GetProductByID(int ProdID, bool trackChanges)
        {

            return await FindByCondition(x => x.ProductID.Equals(ProdID), trackChanges).SingleOrDefaultAsync();

        }

        public async Task<Product> GetProductByName(string name, bool trackChanges)
        {
            return await FindByCondition(x => x.Name.Equals(name), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
    }
}
