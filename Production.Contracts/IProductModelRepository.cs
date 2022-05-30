using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IProductModelRepository
    {
        Task<ProductModel> GetProducModeltByID(int id, bool trackChanges);
        //void Create(ProductModel productModel);
        //void Update(ProductModel productModel);
        //void Delete(ProductModel productModel);
    }
}
