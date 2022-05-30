using Production.Entities.DTO;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct(bool trackChanges);
        Task<Product> GetProductByID(int ProdID, bool trackChanges);
        Task<Product> GetProductByName(string name, bool trackChanges);
        //Task<Product> GetProductBy(int ProdID);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
       
    }
}
