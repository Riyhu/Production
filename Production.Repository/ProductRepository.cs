﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> GetProductByID(int id, bool trackChanges)
        => await FindByCondition(x => x.ProductID.Equals(id), trackChanges).SingleOrDefaultAsync();
        void IProductRepository.Create(Product product)
        {
            Create(product);
        }

        void IProductRepository.Delete(Product product)
        {
            Delete(product);
        }

        void IProductRepository.Update(Product product)
        {
            Update(product);
        }
    }
}
