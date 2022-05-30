using Microsoft.EntityFrameworkCore;
using Production.Contracts;
using Production.Entities.AdventureContexts;
using Production.Entities.Models;
using Production.Entities.RequestFeatures;
using ProductionWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Production.Repository
{
    public class vProductRepository : RepositoryBase<vSearchProduct>, IvProductRepository
    {
        public vProductRepository(AdventureContext adventure) : base(adventure)
        {

        }

        
        public async Task<IEnumerable<vSearchProduct>> SearchProduct(ProductParameters productParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(productParameters.SearchProduct))
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            var lowerCaseSearch = productParameters.SearchProduct.Trim().ToLower();
            var setOrderBy = productParameters.OrderBy.Trim().ToLower();
            var setter = FindAll(trackChanges)
                        .Where(c => c.Name.ToLower().Contains(lowerCaseSearch) ||
                        c.ProductNumber.ToLower().Contains(lowerCaseSearch) ||
                        c.Category.ToLower().Contains(lowerCaseSearch) ||
                        c.SubCategory.ToLower().Contains(lowerCaseSearch));

            if (setOrderBy == "subcategory")
            {
                return await setter.OrderBy(c => c.SubCategory).ThenByDescending(c => c.SafetyStockLevel)
                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                    .Take(productParameters.PageSize)
                    .ToListAsync();
            }
            else if (setOrderBy == "productnumber")
            {
                return await setter.OrderBy(c => c.ProductNumber).ThenByDescending(c => c.SafetyStockLevel)
                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                    .Take(productParameters.PageSize)
                    .ToListAsync();
            }
            else if (setOrderBy == "category")
            {
                return await setter.OrderBy(c => c.Category).ThenByDescending(c => c.SafetyStockLevel)
                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                    .Take(productParameters.PageSize)
                    .ToListAsync();
            }
            else
            {
                return await setter.OrderBy(c => c.Name).ThenByDescending(c => c.SafetyStockLevel)
                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                    .Take(productParameters.PageSize)
                    .ToListAsync();
            }
        }


    }
}
