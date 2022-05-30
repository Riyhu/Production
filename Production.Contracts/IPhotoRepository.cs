using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IPhotoRepository
    {
        Task<ProductPhoto> GetPhotoByID(int id, bool trackChanges);
        //Task<Product> GetProductBy(int ProdID);
        void CreatePhoto(ProductPhoto productPhoto);
        void UpdatePhoto(ProductPhoto productPhoto);
        void DeletePhoto(ProductPhoto productPhoto);
    }
}
