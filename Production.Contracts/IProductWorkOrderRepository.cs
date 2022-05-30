using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IProductWorkOrderRepository
    {
        Task<IEnumerable<Product>> GetAllProductWorkOrder(bool trackChanges);
        Task<Product> GetProductWorkOrderByID(int id, bool trackChanges);
        //Task<Product> GetProductBy(int ProdID);
        void CreateProductWorkOrder(Product product);
        void UpdateProductWorkOrder(Product product);
        void DeleteProductWorkOrder(Product product);
    }
}
