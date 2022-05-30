using Production.Entities.DTO;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IServiceManager
    {
        Task<Product> AddProduct(AddProductDTO addProductDTO);
        Task<AddEditCategoryProductDTO> AddCategoryProduct(AddEditCategoryProductDTO addCategoryProductDTO);
        Task<AddEditCategoryProductDTO> UpdateCategoryProduct(int id, AddEditCategoryProductDTO editCategoryProductDTO);
        Task<bool> DeleteFamilyCategoryProduct(int id, bool trackChanges);
        Task<AddEditCategoryProductDTO> GetProductCategory(int id);
        
    }
}
