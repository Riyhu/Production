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
    public class ProductWorkOrderRepository : RepositoryBase<Product>, IProductWorkOrderRepository
    {
        public ProductWorkOrderRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public void CreateProductWorkOrder(Product product)
        {
            Create(product);
        }

        public void DeleteProductWorkOrder(Product product)
        {
            Delete(product);
        }

        public Task<IEnumerable<Product>> GetAllProductWorkOrder(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductWorkOrderByID(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductID.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateProductWorkOrder(Product product)
        {
            Update(product);
        }
    }
}
