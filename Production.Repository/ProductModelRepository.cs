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
    public class ProductModelRepository : RepositoryBase<ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public async Task<ProductModel> GetProducModeltByID(int id, bool trackChanges)
        => await FindByCondition(x => x.ProductModelID.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
