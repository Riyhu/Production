using Production.Entities.Models;
using Production.Entities.RequestFeatures;
using ProductionWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IvProductRepository
    {
        Task<IEnumerable<vSearchProduct>> SearchProduct(ProductParameters productParameters, bool trackChanges);
        
    }
}
