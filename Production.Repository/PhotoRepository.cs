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
    public class PhotoRepository : RepositoryBase<ProductPhoto>,IPhotoRepository
    {
        public PhotoRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public void CreatePhoto(ProductPhoto productPhoto)
        {
            Create(productPhoto);
        }

        public void DeletePhoto(ProductPhoto productPhoto)
        {
            Delete(productPhoto);
        }

        public async Task<ProductPhoto> GetPhotoByID(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductPhotoID.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdatePhoto(ProductPhoto productPhoto)
        {
            Update(productPhoto);
        }
    }
}
