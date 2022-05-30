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
    public class ProductProductPhotoRepository : RepositoryBase<ProductProductPhoto>, IProductProductPhotoRepository
    {
        public ProductProductPhotoRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public void CreateProductPhotos(ProductProductPhoto productProductPhoto)
        {
            Create(productProductPhoto);
        }
    }
}
