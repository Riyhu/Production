using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Production.Contracts;
using Production.Entities.AdventureContexts;
using Production.Entities.DTO;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Repository
{
    public class AddProductRepository : RepositoryBase<Product>, IAddProductRepository
    {
        public AddProductRepository(AdventureContext adventure) : base(adventure)
        {
        }

       

        public Task<IEnumerable<Product>> GetAllProduct(AddProductDTO addProductDTO, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByID(int ProdID, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductID.Equals(ProdID), trackChanges).SingleOrDefaultAsync();
        }

        void IAddProductRepository.Create(Product product)
        {
            Create(product);
        }

        void IAddProductRepository.Delete(Product product)
        {
            Delete(product);
        }

        void IAddProductRepository.Update(Product product)
        {
            Update(product);
        }
    }
}
